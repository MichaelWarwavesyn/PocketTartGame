using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField]
    private Star starPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private float respawnRate;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
        {
            spawn();
        }
    }

    private void spawn()
    {
        spawnTimer = 0;

        foreach (var spawnPoint in spawnPoints)
        {
            var star = Instantiate(starPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private bool ShouldSpawn()
    {
        return spawnTimer >= respawnRate;
    }
}
