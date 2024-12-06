using System.Collections.Generic;
using UnityEngine;

public class MobsSpawner : MonoBehaviour
{

    [SerializeField]
    private List<Renderer> Mobs;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private float Delay = 1f;

    [SerializeField]
    private LayerMask groundLayer;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= Delay)
        {
            timeSinceLastSpawn = 0f;
            SpawnRandomMob();
        }
    }

    public void SpawnRandomMob()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = Random.Range(10, 50);

        float spawnX = Player.transform.position.x + randomDistance * Mathf.Cos(randomAngle);
        float spawnZ = Player.transform.position.y + randomDistance * Mathf.Sin(randomAngle);

        Vector3 rayOrigin = new(spawnX, 100f, spawnZ);

        if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            int random = Random.Range(0, Mobs.Count);
            Renderer mobToSpawn = Mobs[random];
            float spawnY = hit.point.y + mobToSpawn.bounds.size.y / 2;

            Vector3 randomSpawnPosition = new(spawnX, spawnY, spawnZ);

            Instantiate(mobToSpawn, randomSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Raycast n'a pas touché le sol.");
        }
    }
}
