using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private Collectable[] collectablePrefabs;

    [SerializeField]
    private float initialSpawnDelay;

    [SerializeField]
    private float respawnRate = 10;

    [SerializeField]
    private int totalNumberToSpawn;

    [SerializeField]
    private int numberToSpawnEachTime = 1;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
        {
            spawn();
        }
    }

    private bool ShouldSpawn()
    {
        return spawnTimer >= respawnRate;
    }

    private void spawn()
    {
        spawnTimer = 0;


        Collectable prefab = ChooseRandomCollectablePrefab();

        if (prefab != null)
        {
            Transform spawnPoint = ChooseRandomSpawnPoint();
            var collectable = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private Collectable ChooseRandomCollectablePrefab()
    {
        if (collectablePrefabs.Length == 0)
            return null;

        if (collectablePrefabs.Length == 1)
            return collectablePrefabs[0];

        int index = UnityEngine.Random.Range(0, collectablePrefabs.Length);

        return collectablePrefabs[index];
    }

    private Transform ChooseRandomSpawnPoint()
    {
        if (spawnPoints.Length == 0)
            return transform;

        if (spawnPoints.Length == 1)
            return spawnPoints[0];

        int index = UnityEngine.Random.Range(0, spawnPoints.Length);

        return spawnPoints[index];
    }
}
