using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MobManager : Singleton<MobManager>
{
    [SerializeField]
    private List<Mob> Mobs;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private Text MobLabel;

    [SerializeField]
    private LayerMask groundLayer;


    public UnityEvent<int> OnAmountChange = new();
    public int MobAmount = 0;

    void Start()
    {
        UpdateMobLabel();
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
            Mob mobToSpawn = Mobs[random];
            MeshRenderer renderer = mobToSpawn.GetComponent<MeshRenderer>();
            if (renderer == null) return;

            float spawnY = hit.point.y + renderer.bounds.size.y / 2;

            Vector3 randomSpawnPosition = new(spawnX, spawnY, spawnZ);

            Mob inst = Instantiate(mobToSpawn, randomSpawnPosition, Quaternion.identity);
            inst.OnDie.AddListener(() =>
            {
                --MobAmount;
                UpdateMobLabel();
                OnAmountChange.Invoke(MobAmount);
            });

            ++MobAmount;
            OnAmountChange.Invoke(MobAmount);
        }
        else
        {
            Debug.LogWarning("Raycast n'a pas touché le sol.");
        }

        UpdateMobLabel();
    }

    private void UpdateMobLabel()
    {
        MobLabel.text = "Mobs restants: " + MobAmount;
    }
}
