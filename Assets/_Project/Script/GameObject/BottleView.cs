using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BottleView : MonoBehaviour
{
    [SerializeField] Bottle _bottle;
    [SerializeField] List<Water> _waterList;

    [SerializeField] List<SpriteRenderer> _waterRenderers;
    [SerializeField] SpriteRenderer _bottleRender;

    Stack<Water> _waterStack;

    private void Awake()
    {
        if (_bottle == null)
        {
            Debug.Log("Not set bottle");
        }
        _bottle = GetComponent<Bottle>();

        _bottleRender = GetComponent<SpriteRenderer>();

        _waterRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();

        _waterRenderers.Remove(_bottleRender);
    }

    private void Start()
    {
        _waterStack = _bottle.WaterStack;

        UpdateView();
    }

    private void OnEnable()
    {
        GameActionEvent.PourBottle += OnPour;
    }

    private void OnDisable()
    {
        GameActionEvent.PourBottle -= OnPour;
    }


    private void OnPour(Bottle source, Bottle target, int amount)
    {
        if (_bottle.Equals(source) || _bottle.Equals(target)) UpdateView();
    }

    private void UpdateView()
    {
        _waterList = _waterStack.ToList();

        _waterList.Reverse();

        for (int i = _waterRenderers.Count - 1; i >= 0; i--)
        {
            if (i >= _waterList.Count)
            {
                _waterRenderers[i].color = Color.clear;
            }
            else
            {
                _waterRenderers[i].color = _waterList[i].Color;
            }
        }

    }


}
