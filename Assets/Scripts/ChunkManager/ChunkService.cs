using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkService : MonoBehaviour
{

    [SerializeField]
    private Vector3 Center = Vector3.zero;

    [SerializeField]
    private int ChunkSize = 1;

    [SerializeField]
    private int Render = 3;

    [SerializeField]
    private GameObject ListeningObject;


    private List<Chunk> chunks = new();
    private int previousChunkId;

    // Start is called before the first frame update
    void Start()
    {
        this.previousChunkId = this.GetChunkIdAt(this.ListeningObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        int chunkId = GetChunkIdAt(this.ListeningObject.transform.position);
        if (chunkId == this.previousChunkId) return;

        this.previousChunkId = chunkId;

    }

    public int GetChunkIdAt(Vector3 position)
    {
        Vector3 relativePosition = position - Center;
        Vector2 roundedPosition = new(
            (float)(Math.Round(relativePosition.x / ChunkSize) * ChunkSize),
            (float)(Math.Round(relativePosition.z / ChunkSize) * ChunkSize));

        return ChunkUtils.ConvertToChunkId(roundedPosition);
    }

    private Boolean hasChunk(int chunkId)
    {
        foreach (Chunk item in chunks)
        {
            if (item.GetId() == chunkId)
            {
                return true;
            }
        }

        return false;
    }
}
