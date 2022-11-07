using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotFactory : MonoBehaviour
{
    public List<GameObject> dotPrefabs;
    public float spawnTime = 1f;
    public float spawnDelay = 5f;
    public float spawnRange = 10f;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public GameObject Spawn()
    {
        int prefabIndex = Random.Range(0, dotPrefabs.Count);
        GameObject prefab = dotPrefabs[prefabIndex];

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
        return Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
