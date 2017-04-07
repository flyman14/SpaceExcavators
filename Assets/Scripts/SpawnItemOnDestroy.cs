using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemOnDestroy : MonoBehaviour {
    public SpawnEntry[] spawnOptions;

    int totalWeight = 0;

    private void Start()
    {
        foreach (SpawnEntry entry in spawnOptions)
        {
            totalWeight += entry.spawnRate;
        }
    }

    public void Spawn()
    {
        int randomChoice = Random.Range(0, totalWeight);
        for (int z = 0; z < spawnOptions.Length; z++)
        {
            if (randomChoice < spawnOptions[z].spawnRate)
            {
                if (spawnOptions[z].prefab == null)
                {
                    break;
                }
                Instantiate(spawnOptions[z].prefab, transform.position, transform.rotation);
                break;
            }
            randomChoice -= spawnOptions[z].spawnRate;
        }
    }
}
