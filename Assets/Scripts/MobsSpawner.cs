using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MobsSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject basicMob;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float time = 0.5f;

    [SerializeField]
    private LayerMask groundLayer;

    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= time)
        {
            timeSinceLastSpawn = 0f;

            float randomAngle = UnityEngine.Random.Range(0f, 2f * Mathf.PI); 

            float randomDistance = UnityEngine.Random.Range(10, 20);

            float spawnX = player.transform.position.x + randomDistance * Mathf.Cos(randomAngle);
            float spawnZ = player.transform.position.y + randomDistance * Mathf.Sin(randomAngle);

            Vector3 rayOrigin = new Vector3(spawnX, 100f, spawnZ);
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                float spawnY = hit.point.y + 1;

                Vector3 randomSpawnPosition = new Vector3(spawnX, spawnY, spawnZ);

                Instantiate(basicMob, randomSpawnPosition, Quaternion.identity);
            }
            else
            {
                UnityEngine.Debug.LogWarning("Raycast n'a pas touché le sol.");
            }

        }
    }
}
