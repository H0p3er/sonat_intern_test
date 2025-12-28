
using System;
using System.Collections.Generic;
using UnityEngine;


public class BottleManager : MonoBehaviour
{
    public List<Bottle> Bottles { get; private set; }

    [SerializeField] BottleSpawnHandler _spawnHandler;

    [SerializeField] BottleInteractHandler _interactHandler;


    private void Awake()
    {
        Bottles = new List<Bottle>();

        if (!TryGetComponent(out _spawnHandler)) _spawnHandler = gameObject.AddComponent<BottleSpawnHandler>();

        if (!TryGetComponent(out _interactHandler)) _interactHandler = gameObject.AddComponent<BottleInteractHandler>();


    }

    private void OnEnable()
    {
        ActionEvent.PourBottle += OnPourBottle;
    }

    private void OnDisable()
    {
        ActionEvent.PourBottle -= OnPourBottle;
    }

    private void OnPourBottle(Bottle source, Bottle target, int amount)
    {
        CheckWinCondition();       
    }

    private void CheckWinCondition()
    {
        bool isWinFlag = true;

        foreach (var item in this.Bottles)
        {
            if (!item.IsComplete)
            {
                isWinFlag = false;
                break;
            }
        }

        if (isWinFlag)
        {
            GameEvent.InvokeWin();
        }
    }
}
