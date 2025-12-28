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

        _waterList = _waterStack.ToList();

        while (i < _bottle.WaterDepth) {
            if (i >= _waterRenderers.Count) break;

            if (i >= _waterList.Count)
            {
                _waterRenderers[i].color = Color.clear;
            } else
            {
                _waterRenderers[i].color = _waterList[i].Color;
            }

            i++;
        }

    }


}
