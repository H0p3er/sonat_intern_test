using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAnimationHandler : MonoBehaviour
{
    [SerializeField] Sequence _sequence;

    [SerializeField] Vector3 _anchorPouringPosition = new (0.2f ,0, 0);

    [SerializeField] float _moveDuration = 0.5f;

    [SerializeField] float _pourDuration = 0.5f;

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

    private void OnPourBottle(Bottle source, Bottle target, int amount)
    {
        if (_sequence == null) _sequence = DOTween.Sequence();

        Vector3 sourceOriginPosition = source.transform.position;

        Vector2 targetOriginPosition = target.transform.position;

        _sequence.Append(MoveBottleToPour(source, target));

        _sequence.Append(PouringBottle(source, target, amount));

        _sequence.Append(MoveBottleToOrigin(source, sourceOriginPosition));
    }

    private Sequence MoveBottleToPour(Bottle source, Bottle target)
    {
        Sequence moveSequence = DOTween.Sequence();

        int absPoint = (target.transform.position.x - source.transform.position.x) > 0 ? 1 : -1;

        Vector3 sourcePosition = source.transform.position;

        moveSequence.Append(source.transform.DOMove(sourcePosition + _anchorPouringPosition * absPoint, _moveDuration));

        return moveSequence;
    }

    private Sequence PouringBottle(Bottle source, Bottle target, int amount)
    {
        Sequence pouringSequence = DOTween.Sequence();

        Vector3 angle = (new Vector3(180 , 0 , 0)) / amount;

        pouringSequence.Append(source.transform.DORotate(angle, _pourDuration));

        pouringSequence.Append(source.transform.DORotate(Vector3.zero, _pourDuration));

        return pouringSequence;
    }

    private Sequence MoveBottleToOrigin(Bottle source, Vector3 sourceOriginPosition, Bottle target = null, Vector3 targetOriginPosition = new Vector3())
    {
        Sequence moveSequence = DOTween.Sequence();

        moveSequence.Append(source.transform.DOMove(sourceOriginPosition, _moveDuration));

        return moveSequence;
    }



}
