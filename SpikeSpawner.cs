using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private Spike spike;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private float respawnRate;

    [SerializeField]
    private float lowestSpawnRateTime;

    [SerializeField]
    public float HighestSpawnRateTime;

    private int rotateSpike;

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
        PickNewRandomRespawnRate();

        Spike prefab = spike;

        if (prefab != null)
        {
            Transform spawnPoint = ChooseRandomSpawnPoint();
            var collectable = Instantiate(prefab, spawnPoint.position - RandomOffset(), spawnPoint.rotation * Quaternion.Euler(0, 0, rotateSpike));
        }
    }

    private void PickNewRandomRespawnRate()
    {
        respawnRate = UnityEngine.Random.Range(lowestSpawnRateTime, HighestSpawnRateTime);
    }

    private Vector3 RandomOffset()
    {
        Vector3 offset = new Vector3(0, UnityEngine.Random.Range(-1, 1), 0);

        return offset;
    }

    private bool ShouldSpawn()
    {
        return spawnTimer >= respawnRate;
    }

    private Transform ChooseRandomSpawnPoint()
    {
        if (spawnPoints.Length == 0)
            return transform;

        if (spawnPoints.Length == 1)
            return spawnPoints[0];

        int index = UnityEngine.Random.Range(0, spawnPoints.Length);

        SetRotationBasedOnIndex(index);

        return spawnPoints[index];
    }

    private void SetRotationBasedOnIndex(int index)
    {
        if (index == 0)
        {
            rotateSpike = 180;
        }
        else
        {
            rotateSpike = 0;
        }
    }
}
