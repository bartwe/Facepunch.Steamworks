using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;

[assembly: DoNotParallelize]

namespace Steamworks
{
	[TestClass]
	public sealed class DownloadAsyncTest : IDisposable
	{
		const ulong FileId = 123;
		static MethodInfo processCallback = RequiredMethod( typeof( Dispatch ), "ProcessCallback" );
		SteamUGC ugc = new SteamUGC();
		CancellationTokenSource cancellation = new CancellationTokenSource();
		List<Task<bool>> downloads = new List<Task<bool>>();

		[ClassInitialize]
		public static void LoadStub( TestContext context )
		{
			var library = NativeLibrary.Load( Path.Combine( AppContext.BaseDirectory, "libsteam_ugc_stub.so" ) );
			NativeLibrary.SetDllImportResolver( typeof( SteamUGC ).Assembly, ( name, assembly, path ) =>
				name == "libsteam_api" ? library : throw new DllNotFoundException( name ) );
		}

		[TestInitialize]
		public void Initialize()
		{
			ConfigureDownload( true, 0, IntPtr.Zero );
			Assert.IsTrue( (bool)RequiredMethod( typeof( SteamUGC ), "InitializeInterface" )
				.Invoke( ugc, new object[] { false } )! );
		}

		[TestCleanup]
		public async Task Cleanup()
		{
			try
			{
				// Drain even a regressed, stuck download before tearing down its interface.
				cancellation.Cancel();
				await Task.WhenAll( downloads ).WaitAsync( TimeSpan.FromSeconds( 5 ) );
				foreach ( var field in typeof( SteamUGC ).GetFields( BindingFlags.NonPublic | BindingFlags.Static ) )
				{
					if ( typeof( Delegate ).IsAssignableFrom( field.FieldType ) )
						Assert.IsNull( field.GetValue( null ), $"Leaked subscription: {field.Name}" );
				}
			}
			finally
			{
				RequiredMethod( typeof( SteamUGC ), "DestroyInterface" ).Invoke( ugc, new object[] { false } );
				RequiredMethod( typeof( Dispatch ), "ShutdownClient" ).Invoke( null, null );
			}
		}

		public void Dispose()
		{
			cancellation.Dispose();
			GC.SuppressFinalize( this );
		}

		[TestMethod]
		[DataRow( Result.Fail, false )]
		[DataRow( Result.AccessDenied, false )]
		[DataRow( Result.DiskFull, false )]
		[DataRow( Result.Fail, true )]
		public async Task FailedResultReturnsFalseWithoutCancellation( Result result, bool installed )
		{
			ConfigureDownload( true, installed ? (uint)ItemState.Installed : 0, IntPtr.Zero );
			var progress = new List<float>();
			var download = StartDownload( progress.Add );
			DispatchResult( FileId, result );

			Assert.IsFalse( await download.WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
			Assert.IsFalse( cancellation.IsCancellationRequested );
			Assert.AreEqual( 1, progress.Count );
			Assert.AreEqual( 0.0f, progress[0] );
		}

		[TestMethod]
		public async Task SuccessfulResultReturnsTrueForInstalledItem()
		{
			ConfigureDownload( true, (uint)ItemState.Installed, IntPtr.Zero );
			var progress = new List<float>();
			var download = StartDownload( progress.Add );
			DispatchResult( FileId, Result.OK );

			Assert.IsTrue( await download.WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
			Assert.AreEqual( 1.0f, progress[progress.Count - 1] );
		}

		[TestMethod]
		[DataRow( Result.Fail )]
		[DataRow( Result.OK )]
		public async Task IgnoresOtherItemsWhilePreservingPublicEvent( Result unrelatedResult )
		{
			ConfigureDownload( true, (uint)ItemState.Installed, IntPtr.Zero );
			var results = new List<Result>();
			SteamUGC.OnDownloadItemResult += results.Add;
			try
			{
				var download = StartDownload();
				DispatchResult( FileId + 1, unrelatedResult );
				await Task.Delay( 100 );
				Assert.IsFalse( download.IsCompleted );
				DispatchResult( FileId, Result.OK );
				Assert.IsTrue( await download.WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
				CollectionAssert.AreEqual( new[] { unrelatedResult, Result.OK }, results );
			}
			finally
			{
				SteamUGC.OnDownloadItemResult -= results.Add;
			}
		}

		[TestMethod]
		public async Task HandlesResultDispatchedDuringDownloadRequest()
		{
			DownloadCallback callback = () => DispatchResult( FileId, Result.Fail );
			ConfigureDownload( true, 0, Marshal.GetFunctionPointerForDelegate( callback ) );
			try
			{
				Assert.IsFalse( await StartDownload().WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
			}
			finally
			{
				ConfigureDownload( true, 0, IntPtr.Zero );
				GC.KeepAlive( callback );
			}
		}

		[TestMethod]
		[DataRow( false )]
		[DataRow( true )]
		public async Task RejectedRequestReturnsInstalledState( bool installed )
		{
			ConfigureDownload( false, installed ? (uint)ItemState.Installed : 0, IntPtr.Zero );
			Assert.AreEqual( installed, await StartDownload().WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
		}

		[TestMethod]
		public async Task CancellationWithoutResultCompletes()
		{
			var download = StartDownload();
			cancellation.Cancel();
			Assert.IsFalse( await download.WaitAsync( TimeSpan.FromSeconds( 2 ) ) );
		}

		Task<bool> StartDownload( Action<float>? progress = null )
		{
			var download = SteamUGC.DownloadAsync( FileId, progress, 10, cancellation.Token );
			downloads.Add( download );
			return download;
		}

		static void DispatchResult( ulong fileId, Result result )
		{
			var data = new DownloadResult { AppId = 1, FileId = fileId, Result = result };
			var pointer = Marshal.AllocHGlobal( Marshal.SizeOf<DownloadResult>() );
			try
			{
				Marshal.StructureToPtr( data, pointer, false );
				var messageType = processCallback.GetParameters()[0].ParameterType;
				var message = Activator.CreateInstance( messageType )!;
				messageType.GetField( "Type" )!.SetValue( message, CallbackType.DownloadItemResult );
				messageType.GetField( "Data" )!.SetValue( message, pointer );
				messageType.GetField( "DataSize" )!.SetValue( message, Marshal.SizeOf<DownloadResult>() );
				processCallback.Invoke( null, new[] { message, (object)false } );
			}
			finally
			{
				Marshal.FreeHGlobal( pointer );
			}
		}

		static MethodInfo RequiredMethod( Type type, string name ) =>
			type.GetMethod( name, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance )
			?? throw new InvalidOperationException( $"Missing method: {type.FullName}.{name}" );

		[StructLayout( LayoutKind.Sequential, Pack = 4 )]
		struct DownloadResult
		{
			public uint AppId;
			public ulong FileId;
			public Result Result;
		}

		[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
		delegate void DownloadCallback();

		[DllImport( "libsteam_ugc_stub", CallingConvention = CallingConvention.Cdecl )]
		static extern void ConfigureDownload( [MarshalAs( UnmanagedType.I1 )] bool accept, uint state, IntPtr callback );
	}
}
