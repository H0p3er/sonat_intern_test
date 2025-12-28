using System;
using UnityEngine;

public class BottleSpawnHandler : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] BottleSpawnDataSO spawnData;

    void Start()
    {
        if (spawnData.numberPerRow == 0) return;

        for (int i = 0; i < spawnData.numberOfBottles; i++) {

            GameObject gameObject = Instantiate(prefab, this.transform);

            if (gameObject.TryGetComponent(out Bottle bottle))
            {

            }

        }      
    }



}

