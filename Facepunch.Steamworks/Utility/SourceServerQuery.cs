﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks;

static class SourceServerQuery {
    //      private static readonly byte A2S_PLAYER = 0x55;
    const byte A2S_RULES = 0x56;
    static readonly byte[] A2S_SERVERQUERY_GETCHALLENGE = { 0x55, 0xFF, 0xFF, 0xFF, 0xFF };

    static readonly Dictionary<IPEndPoint, Task<Dictionary<string, string>>> PendingQueries =
        new();

    internal static Task<Dictionary<string, string>> GetRules(ServerInfo server) {
        var endpoint = new IPEndPoint(server.Address, server.QueryPort);

        lock (PendingQueries) {
            if (PendingQueries.TryGetValue(endpoint, out var pending))
                return pending;

            var task = GetRulesImpl(endpoint)
                .ContinueWith(
                    t => {
                        lock (PendingQueries) {
                            _ = PendingQueries.Remove(endpoint);
                        }

                        return t;
                    }
                )
                .Unwrap();

            PendingQueries.Add(endpoint, task);
            return task;
        }
    }

    static async Task<Dictionary<string, string>> GetRulesImpl(IPEndPoint endpoint) {
        try {
            using var client = new UdpClient();
            client.Client.SendTimeout = 3000;
            client.Client.ReceiveTimeout = 3000;
            client.Connect(endpoint);

            return await GetRules(client);
        }
        catch (Exception) {
            //Console.Error.WriteLine( e.Message );
            return null;
        }
    }

    static async Task<Dictionary<string, string>> GetRules(UdpClient client) {
        var challengeBytes = await GetChallengeData(client);
        challengeBytes[0] = A2S_RULES;
        await Send(client, challengeBytes);
        var ruleData = await Receive(client);

        var rules = new Dictionary<string, string>();

        using (var br = new BinaryReader(new MemoryStream(ruleData))) {
            if (br.ReadByte() != 0x45)
                throw new("Invalid data received in response to A2S_RULES request");

            var numRules = br.ReadUInt16();
            for (var index = 0; index < numRules; index++) {
                rules.Add(br.ReadNullTerminatedUTF8String(), br.ReadNullTerminatedUTF8String());
            }
        }

        return rules;
    }


    static async Task<byte[]> Receive(UdpClient client) {
        byte[][] packets = null;
        byte packetNumber = 0, packetCount = 1;

        do {
            var result = await client.ReceiveAsync();
            var buffer = result.Buffer;

            using var br = new BinaryReader(new MemoryStream(buffer));
            var header = br.ReadInt32();

            if (header == -1) {
                var unsplitdata = new byte[buffer.Length - br.BaseStream.Position];
                Buffer.BlockCopy(buffer, (int)br.BaseStream.Position, unsplitdata, 0, unsplitdata.Length);
                return unsplitdata;
            }
            if (header == -2) {
                var requestId = br.ReadInt32();
                packetNumber = br.ReadByte();
                packetCount = br.ReadByte();
                var splitSize = br.ReadInt32();
            }
            else {
                throw new("Invalid Header");
            }

            if (packets == null)
                packets = new byte[packetCount][];

            var data = new byte[buffer.Length - br.BaseStream.Position];
            Buffer.BlockCopy(buffer, (int)br.BaseStream.Position, data, 0, data.Length);
            packets[packetNumber] = data;
        } while (packets.Any(p => p == null));

        var combinedData = Combine(packets);
        return combinedData;
    }

    static async Task<byte[]> GetChallengeData(UdpClient client) {
        await Send(client, A2S_SERVERQUERY_GETCHALLENGE);

        var challengeData = await Receive(client);

        if (challengeData[0] != 0x41)
            throw new("Invalid Challenge");

        return challengeData;
    }

    static async Task Send(UdpClient client, byte[] message) {
        var sendBuffer = new byte[message.Length + 4];

        sendBuffer[0] = 0xFF;
        sendBuffer[1] = 0xFF;
        sendBuffer[2] = 0xFF;
        sendBuffer[3] = 0xFF;

        Buffer.BlockCopy(message, 0, sendBuffer, 4, message.Length);

        _ = await client.SendAsync(sendBuffer, message.Length + 4);
    }

    static byte[] Combine(byte[][] arrays) {
        var rv = new byte[arrays.Sum(a => a.Length)];
        var offset = 0;
        foreach (var array in arrays) {
            Buffer.BlockCopy(array, 0, rv, offset, array.Length);
            offset += array.Length;
        }
        return rv;
    }
}
