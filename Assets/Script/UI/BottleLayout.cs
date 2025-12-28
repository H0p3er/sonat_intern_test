using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BottleLayout : MonoBehaviour
{
    [SerializeField] List<Bottle> _bottles;

    private void Awake()
    {
        if (_bottles == null) _bottles = GetComponentsInChildren<Bottle>().ToList();
    }

    private void OnEnable()
    {
        ActionEvent.PourBottle += OnPourBottle;
    }

    private void OnDisable()
    {
        ActionEvent.PourBottle -= OnPourBottle;
    }

    void Start()
    {
        SetBottleLayout();
    }

    private void SetBottleLayout()
    {
        float x;

        Vector3 bottlePosition;

        float pivotX = transform.position.x;

        for (int i = 0; i < _bottles.Count / 2; i++)
        {
            x = i - (float)_bottles.Count / 2;

            bottlePosition = new Vector3(pivotX + x, 0, 0);

            _bottles[i].transform.position = bottlePosition;
        }



        for (int i = _bottles.Count / 2; i < _bottles.Count; i++)
        {
            x = _bottles.Count - i;

            bottlePosition = new Vector3(pivotX + x, 0, 0);

            _bottles[i].transform.position = bottlePosition;
        }
    }


    private void OnPourBottle(Bottle source, Bottle target, int arg2)
    {
        
    }


    private void CheckWinCondition()
    {
        bool isWinFlag = true;

        foreach (var item in _bottles)
        {
            if (!item.IsComplete) {
                isWinFlag = false;
                break;
            }
        }

        if (isWinFlag) {
            GameEvent.InvokeWin();     
        }
    }

}
