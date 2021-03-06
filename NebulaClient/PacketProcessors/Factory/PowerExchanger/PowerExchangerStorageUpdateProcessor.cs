﻿using NebulaModel.Attributes;
using NebulaModel.Networking;
using NebulaModel.Packets.Factory.PowerExchanger;
using NebulaModel.Packets.Processors;

namespace NebulaClient.PacketProcessors.Factory.PowerExchanger
{
    [RegisterPacketProcessor]
    class PowerExchangerStorageUpdateProcessor : IPacketProcessor<PowerExchangerStorageUpdatePacket>
    {
        public void ProcessPacket(PowerExchangerStorageUpdatePacket packet, NebulaConnection conn)
        {
            PowerExchangerComponent[] pool = GameMain.data.factories[packet.FactoryIndex]?.powerSystem?.excPool;
            if (pool != null && packet.PowerExchangerIndex != -1 && packet.PowerExchangerIndex < pool.Length && pool[packet.PowerExchangerIndex].id != -1)
            {
                pool[packet.PowerExchangerIndex].SetEmptyCount(packet.EmptyAccumulatorCount);
                pool[packet.PowerExchangerIndex].SetFullCount(packet.FullAccumulatorCount);
            }
        }
    }
}