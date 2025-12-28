using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawnHandler : MonoBehaviour
{
    [SerializeField] GameObject _prefab;

    [SerializeField] BottleSpawnDataSO _spawnData;

    [SerializeField] BottleManager _bottleManager;

    [SerializeField] List<Bottle> _bottles;

    private void Awake()
    {
        if (!TryGetComponent(out _bottleManager)) _bottleManager = gameObject.AddComponent<BottleManager>();

        _bottles = _bottleManager.Bottles;
    }

    void Start()
    {
        SpawnBottle();
    }

    private void SpawnBottle()
    {
        if (_bottles == null || _spawnData == null || _spawnData.bottles == null) {
            Debug.Log("Bottle is null");
            return;
        }
        

        foreach (var item in _spawnData.bottles)
        {
            GameObject gameObject = Instantiate(_prefab, this.transform);

            if (!gameObject.TryGetComponent(out Bottle bottle)) bottle = gameObject.AddComponent<Bottle>();

            _bottles.Add(bottle);

            bottle.SetWaterStackFromList(item.water);
        }
    }

}

