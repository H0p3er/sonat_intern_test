using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAnimationHandler : MonoBehaviour
{
    [SerializeField] Sequence _sequence;

    [SerializeField] Vector2 _anchorPouringPosition = new (0.2f ,0);

    [SerializeField] float _moveDuration = 0.5f;

    [SerializeField] float _pourDuration = 0.5f;

    [SerializeField] float _pourAngleLimit = 160f;

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
        if (_sequence.IsActive())
        {
            _sequence.Kill();
            _sequence.OnKill(() => { _sequence = null;  });
        }       
    }

    private void OnPourBottle(Bottle source, Bottle target, int amount)
    {

        if (!_sequence.IsActive() || _sequence.IsComplete()) _sequence = DOTween.Sequence();

        Vector3 sourceOriginPosition = source.transform.position;

        Vector3 targetOriginPosition = target.transform.position;

        int absPoint = (targetOriginPosition.x - sourceOriginPosition.x) > 0 ? -1 : 1;

        _sequence.Append(MoveBottleToPour(source, target, absPoint));

        _sequence.Append(PouringBottle(source, target, absPoint, amount));

        _sequence.Append(MoveBottleToOrigin(source, sourceOriginPosition));

        _sequence.Play();
    }

    private Sequence MoveBottleToPour(Bottle source, Bottle target, int absPoint)
    {
        Sequence moveSequence = DOTween.Sequence();

        Vector3 targetPosition = target.transform.position + new Vector3(_anchorPouringPosition.x * absPoint, _anchorPouringPosition.y);

        moveSequence.Append(source.transform.DOMove(targetPosition, _moveDuration));

        moveSequence.Pause();

        return moveSequence;
    }

    private Sequence PouringBottle(Bottle source, Bottle target, int absPoint, int amount)
    {
        Sequence pouringSequence = DOTween.Sequence();

        Vector3 angle = absPoint * amount * new Vector3(0 , 0 , _pourAngleLimit) / source.WaterDepth;

        pouringSequence.Append(source.transform.DORotate(angle, _pourDuration));

        pouringSequence.Append(source.transform.DORotate(Vector3.zero, _pourDuration));

        pouringSequence.Pause();

        return pouringSequence;
    }

    private Sequence MoveBottleToOrigin(Bottle source, Vector3 sourceOriginPosition, Bottle target = null, Vector3 targetOriginPosition = new Vector3())
    {
        Sequence moveSequence = DOTween.Sequence();

        moveSequence.Append(source.transform.DOMove(sourceOriginPosition, _moveDuration));

        moveSequence.Pause();

        return moveSequence;
    }



}
