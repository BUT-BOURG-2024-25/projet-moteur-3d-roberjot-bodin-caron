using System;
using System.Collections.Generic;
using UnityEngine;

public class ChunkService : Singleton<ChunkService>
{

    [SerializeField]
    private Vector3 Center = Vector3.zero;

    [SerializeField]
    private int ChunkSize = 10;

    [SerializeField]
    private Chunk chunkRef;

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
        this._updateChunks();
    }

    // Update is called once per frame
    void Update()
    {
        int chunkId = this.GetChunkIdAt(this.ListeningObject.transform.position);
        if (chunkId == this.previousChunkId) return;

        this.previousChunkId = chunkId;
        this._updateChunks();
    }

    private void _updateChunks()
    {
        Vector2 pRelativePos = GetRelativePosition(this.ListeningObject.transform.position);

        for(int i = 0; i < chunks.Count; ++i)
        {
            Chunk chunk = chunks[i];
            if ((chunk.RelativePosition - pRelativePos).magnitude > Render)
            {
                --i;
                chunks.Remove(chunk);
                Destroy(chunk.gameObject);
            }
        }

        Vector3 listeningPos = this.ListeningObject.transform.position;
        for (int i = -Render; i <= Render; i++)
        {
            for(int j = -Render; j <= Render; j++)
            {
                Vector2 chunkPos = new Vector2(i, j) + pRelativePos;
                int chunkId = ChunkUtils.ConvertToChunkId(chunkPos);
                if (!_hasChunk(chunkId))
                {
                    Chunk newChunk = GameObject.Instantiate<Chunk>(chunkRef);
                    Vector3 worldPos = new Vector3(chunkPos.x, 0, chunkPos.y) * ChunkSize + Center;

                    newChunk.transform.position = worldPos;
                    newChunk.transform.localScale = Vector3.one * ChunkSize / 10;

                    newChunk.Load(chunkPos);

                    chunks.Add(newChunk);
                }
            }
        }
    }

    public int GetChunkIdAt(Vector3 position)
    {
        return ChunkUtils.ConvertToChunkId(GetRelativePosition(position));
    }

    

    public Vector2 GetRelativePosition(Vector3 position)
    {
        Vector3 relativePosition = position - Center;
        Vector2 roundedPosition = new(
            (float)(Math.Round(relativePosition.x / ChunkSize)),
            (float)(Math.Round(relativePosition.z / ChunkSize)));

        return roundedPosition;
    }

    private Boolean _hasChunk(int chunkId)
    {
        foreach (Chunk item in chunks)
        {
            if (item.Id == chunkId)
            {
                return true;
            }
        }

        return false;
    }
}
