using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerMain : MonoBehaviour {
    const int mapCellWidth = 100;
    const int mapCellHeight = 100;
    const float spaceBetweenUnits = 5f;
    const float activationCutoff = 800;

    public SpawnEntry[] spawnOptions;
    
    int[,] mapSpawnData = new int[mapCellWidth, mapCellHeight];
    

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < mapCellHeight; i++)
        {
            for (int j = 0; j < mapCellWidth; j++)
            {
                mapSpawnData[j, i] = -1;
            }
        }
        MakeMap();
        SpawnMap();
    }
	
    void MakeMap()
    {
        for (int i = 0; i < mapCellHeight; i++)
        {
            for (int j = 0; j < mapCellWidth; j++)
            {
                for (int z = 0; z < spawnOptions.Length; z++)
                {
                    if (Random.value < spawnOptions[z].spawnRate)
                    {
                        mapSpawnData[j, i] = z;
                        break;
                    }
                }
                
            }
        }
        
    }

    void SpawnMap()
    {
        Vector3 spawnPos;
        Quaternion spawnRot = Quaternion.identity;

        for (int i = 0; i < mapCellHeight; i++)
        {
            for (int j = 0; j < mapCellWidth; j++)
            {
                if (mapSpawnData[j, i] == -1)
                {
                    continue;
                }

                spawnPos = new Vector3(j * spaceBetweenUnits - mapCellWidth*spaceBetweenUnits/2, 0, i * spaceBetweenUnits - mapCellHeight*spaceBetweenUnits/2);

                GameObject newObject = Instantiate(spawnOptions[mapSpawnData[j, i]].prefab, spawnPos, spawnRot);
                if ((newObject.transform.position - PlayerController.player.transform.position).sqrMagnitude > activationCutoff)
                {
                    newObject.GetComponent<ActivationController>().ToggleActivation(false);
                }
            }
        }
    }

}

enum SpawnType
{
    ASTEROID,
    PLANET,
    ENEMY,
    NONE
};

[System.Serializable]
public struct SpawnEntry
{
    public GameObject prefab;
    public float spawnRate;
}