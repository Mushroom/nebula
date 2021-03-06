﻿using NebulaModel.Attributes;
using NebulaModel.Networking;
using NebulaModel.Packets.Factory.Laboratory;
using NebulaModel.Packets.Processors;

namespace NebulaHost.PacketProcessors.Factory.Labratory
{
    [RegisterPacketProcessor]
    class LaboratoryUpdateStorageProcessor : IPacketProcessor<LaboratoryUpdateStoragePacket>
    {
        public void ProcessPacket(LaboratoryUpdateStoragePacket packet, NebulaConnection conn)
        {
            LabComponent[] pool = GameMain.data.factories[packet.FactoryIndex]?.factorySystem?.labPool;
            if (pool != null && packet.LabIndex != -1 && packet.LabIndex < pool.Length && pool[packet.LabIndex].id != -1)
            {
                pool[packet.LabIndex].served[packet.Index] = packet.Value;
            }
        }
    }
}