using UnityEngine;
using Mirror;
using System;

public class SerializationExample : MonoBehaviour
{
    public struct PositionChange : NetworkMessage
    {
        public double newPosX;
        public double newPosY;
        public double newPosZ;
    }

    private PositionChange myStoredPos;

    private void Update()
    {
        PositionChange testPosChange
            = new PositionChange { newPosX = 6, newPosY = 9, newPosZ = 4 };

        NetworkWriterPooled writer = NetworkWriterPool.Get();
        writer.Write(testPosChange);
        ArraySegment<byte> writerBuffer = writer.ToArraySegment();

        NetworkReaderPooled reader = NetworkReaderPool.Get(writerBuffer);
        PositionChange deserializedPosition = reader.Read<PositionChange>();
        myStoredPos = deserializedPosition;

        NetworkWriterPool.Return(writer);
        NetworkReaderPool.Return(reader);
    }

    public class Tree
    {
        public ushort branchCount;

        public void Deserialize(NetworkReaderPooled reader)
        {
            branchCount = reader.ReadUShort();
        }

        public void Serialize(NetworkWriterPooled writer)
        {
            writer.WriteUShort(branchCount);
        }
    }
}
