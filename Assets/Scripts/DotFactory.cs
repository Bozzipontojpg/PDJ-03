using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotFactory : MonoBehaviour
{
    public GameObject dotPrefab;
    public List<DotData> dotDatas;
    public float spawnTime = 1f;
    public float spawnDelay = 5f;
    public Transform[] spawnRange = new Transform[2];

    public int enemySpawnChance = 10;

    private Dot dot;

    public void SpawnDot()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }
    
    public void DestroyDot()
    {
        CancelInvoke("Spawn");
        foreach (Transform d in transform)
        {
            Destroy(d.gameObject);
        }
    }

    public GameObject Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(spawnRange[0].position.x, spawnRange[1].position.x), 0, Random.Range(spawnRange[0].position.z, spawnRange[1].position.z));

        int spawnChance = Random.Range(0, 100);

        GameObject prefab = Instantiate(dotPrefab, spawnPosition, Quaternion.identity, this.transform);

        if(spawnChance > enemySpawnChance)
        {
            dot = new NormalDot(prefab, dotDatas[Random.Range(0,2)]);
        }
        else
        {
            dot = new EnemyDot(prefab, dotDatas[2]);
        }
        dot.CreateDot();

        return prefab;
    }
}
