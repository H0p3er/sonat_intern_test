using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawnHandler : MonoBehaviour
{

    [SerializeField] BottleManager _bottleManager;

    [SerializeField] GameObject _prefab;

    [SerializeField] BottleSpawnDataSO _spawnData;

    [SerializeField] List<Bottle> _bottles;

    [SerializeField] float _padding = 1f;

    private void Awake()
    {
        if (!TryGetComponent(out _bottleManager)) _bottleManager = gameObject.AddComponent<BottleManager>();
    }

    void Start()
    {
        _bottles = _bottleManager.Bottles;
        SpawnBottle();
        SetBottleLayout();
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


    private void SetBottleLayout()
    {
        float x;

        Vector3 bottlePosition;

        float pivotX = transform.position.x;

        for (int i = 0; i < _bottles.Count / 2; i++)
        {
            x = i - (float)_bottles.Count / 2;

            bottlePosition = new Vector3(pivotX + x * _padding, 0, 0);

            _bottles[i].transform.position = bottlePosition;
        }



        for (int i = _bottles.Count / 2; i < _bottles.Count; i++)
        {
            x = _bottles.Count - i;

            bottlePosition = new Vector3(pivotX + x * _padding, 0, 0);

            _bottles[i].transform.position = bottlePosition;
        }
    }


}

