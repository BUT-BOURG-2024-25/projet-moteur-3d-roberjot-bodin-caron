using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2 RelativePosition { get; private set; }
    public int Id { get; private set; }
    public void Load(Vector2 relativePos)
    {
        this.RelativePosition = relativePos;
        this.Id = ChunkUtils.ConvertToChunkId(RelativePosition);
    }
}
