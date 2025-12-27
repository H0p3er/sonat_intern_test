using System;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] BottleSpawnData spawnData;

    void Start()
    {
        for (int i = 0; i < spawnData.numberOfBottles; i++) {

            int x = i % spawnData.numberPerRow;

            int y = i / spawnData.numberPerRow;

            Vector3 position = transform.position + new Vector3(x, y, 0);

            Instantiate(prefab, position , Quaternion.identity);
        }      
    }

}

[Serializable]
public class BottleSpawnData
{
    public int numberOfBottles;

    public int numberPerRow;

    

}