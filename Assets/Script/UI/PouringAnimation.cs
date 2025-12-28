using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PouringAnimation : MonoBehaviour
{
    Sequence _sequence;

    private void OnEnable()
    {
        ActionEvent.PourBottle += OnPourBottle;
    }

    private void OnDisable()
    {
        ActionEvent.PourBottle -= OnPourBottle;
    }

    private void OnDestroy()
    {
        if ( _sequence != null && _sequence.IsPlaying())
        {
            _sequence.Kill();
            _sequence.OnKill(() => { _sequence = null;  });
        }
        
    }

    private void OnPourBottle(Bottle source, Bottle target, int arg3)
    {
        if (_sequence == null) _sequence = DOTween.Sequence();


    }

    private void Update()
    {

    }

}
