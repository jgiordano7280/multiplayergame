using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    private float nextSpawnTime;

    void Update()
    {
        if (!isServer)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        float rand = UnityEngine.Random.Range(-5.0f, 6.0f);
        Vector3 spawnPosition = new Vector3(15, rand, 0);
        var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        NetworkServer.Spawn(enemy);
    }
}
