using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    public List<Bottle> Bottles { get; private set; }

    [SerializeField] BottleSpawnHandler _spawnHandler;

    [SerializeField] BottleInteractHandler _interactHandler;

    [SerializeField] BottleLayoutHandler _layoutHandler;


    private void Awake()
    {
        Bottles = new List<Bottle>();

        if (!TryGetComponent(out _spawnHandler)) _spawnHandler = gameObject.AddComponent<BottleSpawnHandler>();

        if (!TryGetComponent(out _interactHandler)) _interactHandler = gameObject.AddComponent<BottleInteractHandler>();

        if (!TryGetComponent(out _layoutHandler)) _layoutHandler = gameObject.AddComponent<BottleLayoutHandler>();


    }
}
