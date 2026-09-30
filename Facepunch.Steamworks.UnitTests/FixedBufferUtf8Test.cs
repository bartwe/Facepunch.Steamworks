using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Steamworks
{
	[TestClass]
	public class FixedBufferUtf8Test
	{
		public static IEnumerable<object[]> FixedBuffers()
		{
			foreach ( var type in typeof( SteamUser ).Assembly.GetTypes() )
			{
				if ( type.Namespace != "Steamworks.Data" || !type.IsValueType )
					continue;

				foreach ( var method in type.GetMethods( BindingFlags.Instance | BindingFlags.NonPublic ) )
				{
					if ( !method.Name.EndsWith( "UTF8", StringComparison.Ordinal ) )
						continue;

					var fieldName = method.Name.Substring( 0, method.Name.Length - 4 );
					var field = type.GetField( fieldName, BindingFlags.Instance | BindingFlags.NonPublic )
						?? throw new InvalidOperationException( $"Missing field for {type.Name}.{method.Name}." );
					var layout = field.GetCustomAttribute<MarshalAsAttribute>()
						?? throw new InvalidOperationException( $"Missing layout for {type.Name}.{fieldName}." );
					yield return new object[] { type.FullName!, fieldName, layout.SizeConst };
				}
			}
		}

		[TestMethod]
		[DynamicData( nameof( FixedBuffers ) )]
		public void DecodesFullBufferWithoutTerminator( string typeName, string fieldName, int capacity )
		{
			var expected = "é" + new string( 'x', capacity - 2 );
			var buffer = Encoding.UTF8.GetBytes( expected );
			Assert.AreEqual( capacity, buffer.Length );
			Assert.AreEqual( -1, Array.IndexOf( buffer, (byte)0 ) );
			Assert.AreEqual( expected, Decode( typeName, fieldName, buffer ) );
		}

		[TestMethod]
		[DynamicData( nameof( FixedBuffers ) )]
		public void StopsAtFirstTerminator( string typeName, string fieldName, int capacity )
		{
			foreach ( var length in new[] { 0, capacity / 2, capacity - 1 } )
			{
				var buffer = new byte[capacity];
				Array.Fill( buffer, (byte)'x' );
				buffer[length] = 0;
				Assert.AreEqual( new string( 'x', length ), Decode( typeName, fieldName, buffer ) );
			}
		}

		[TestMethod]
		[DynamicData( nameof( FixedBuffers ) )]
		public void RejectsNullBuffer( string typeName, string fieldName, int capacity )
		{
			var exception = Assert.ThrowsExactly<TargetInvocationException>( () => Decode( typeName, fieldName, null ) );
			Assert.IsInstanceOfType<ArgumentNullException>( exception.InnerException );
		}

		static string Decode( string typeName, string fieldName, byte[]? buffer )
		{
			var type = typeof( SteamUser ).Assembly.GetType( typeName, throwOnError: true )!;
			var instance = Activator.CreateInstance( type )!;
			var field = type.GetField( fieldName, BindingFlags.Instance | BindingFlags.NonPublic )
				?? throw new InvalidOperationException( $"Missing field {typeName}.{fieldName}." );
			var method = type.GetMethod( fieldName + "UTF8", BindingFlags.Instance | BindingFlags.NonPublic )
				?? throw new InvalidOperationException( $"Missing decoder for {typeName}.{fieldName}." );
			field.SetValue( instance, buffer );
			return (string)method.Invoke( instance, null )!;
		}
	}
}
