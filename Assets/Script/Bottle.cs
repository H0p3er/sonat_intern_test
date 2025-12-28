using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;


public class Bottle : MonoBehaviour
{
    [SerializeField] int _waterDepth = 4;

    public int WaterDepth { get => _waterDepth; }
    public Stack<Water> WaterStack { get; private set; }

    public bool IsComplete {
        get
        {           

            bool isCompleteFlag = true;

            List<Water> waterList = WaterStack.ToList();

            for (int i = 0; i < waterList.Count - 1; i++)
            {
                if (!waterList[i].Equals(waterList[i + 1])) return false;
            }

            return isCompleteFlag;
        }
    
    }

    public bool IsFull => _waterDepth <= WaterStack.Count;

    private void Awake()
    {
        WaterStack = new Stack<Water>(_waterDepth);

    }
}

public class BottleView : MonoBehaviour
{

    [SerializeField] Bottle _bottle;
    [SerializeField] List<Water> _waterList;
    [SerializeField] List<SpriteRenderer> _spriteRenderers;

    private void Awake()
    {
        _bottle = GetComponent<Bottle>();

        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
    }

    private void Start()
    {
        _waterList = _bottle.WaterStack.ToList();

        UpdateView();
    }

    private void OnEnable()
    {
        ActionEvent.PourBottle += OnPour;
    }

    private void OnDisable()
    {
        ActionEvent.PourBottle -= OnPour;
    }


    private void OnPour(Bottle source, Bottle target, int amount)
    {
        if (_bottle.Equals(source) || _bottle.Equals(target)) UpdateView();
    }

    private void UpdateView()
    {

        int i = 0;

        while (i < _bottle.WaterDepth) {
            if (i > _spriteRenderers.Count) break;

            if (i > _waterList.Count)
            {
                _spriteRenderers[i].color = Color.clear;
            } else
            {
                _spriteRenderers[i].color = _waterList[i].color;
            }

            i++;
        }

    }


}
