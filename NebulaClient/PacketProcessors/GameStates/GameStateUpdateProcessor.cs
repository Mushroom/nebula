﻿using NebulaModel.Attributes;
using NebulaModel.DataStructures;
using NebulaModel.Networking;
using NebulaModel.Packets.GameStates;
using NebulaModel.Packets.Processors;
using NebulaModel.Utils;
using NebulaWorld;

namespace NebulaClient.PacketProcessors.GameStates
{
    [RegisterPacketProcessor]
    public class GameStateUpdateProcessor : IPacketProcessor<GameStateUpdate>
    {
        public void ProcessPacket(GameStateUpdate packet, NebulaConnection conn)
        {
            GameState state = packet.State;

            // We offset the tick received to account for the time it took to receive the packet
            long timeOffset = TimeUtils.CurrentUnixTimestampMilliseconds() - packet.State.timestamp;
            long tickOffsetSinceSent = (long)System.Math.Round(timeOffset / (GameMain.tickDeltaTime * 1000));
            state.gameTick += tickOffsetSinceSent;

            SimulatedWorld.UpdateGameState(state);
        }
    }
}
