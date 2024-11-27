using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    private Vector2 position;
    private int chunkId;
    

    Chunk(Vector2 chunkPos)
    {
        this.position = chunkPos;
        this.chunkId = ChunkUtils.ConvertToChunkId(chunkPos);
    }

    private void start()
    {

    }

    public int GetId()
    {
        return this.chunkId;
    }
}
