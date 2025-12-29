using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class BottleAnimationHandler : MonoBehaviour
{
    [SerializeField] Sequence _sequence;

    [SerializeField] float _moveDuration = 0.5f;


    private void OnEnable()
    {
        GameActionEvent.PourBottle += OnPourBottle;
        GameActionEvent.SelectBottle += OnSelectBottle;
        GameActionEvent.RemoveSelectBottle += OnRemoveSelectBottle;
    }


    private void OnDisable()
    {
        GameActionEvent.PourBottle -= OnPourBottle;
        GameActionEvent.SelectBottle -= OnSelectBottle;
        GameActionEvent.RemoveSelectBottle -= OnRemoveSelectBottle;
    }

    private void OnDestroy()
    {
        if (_sequence.IsActive())
        {
            _sequence.Kill();
            _sequence.OnKill(() => { _sequence = null;  });
        }       
    }

}

public partial class BottleAnimationHandler : MonoBehaviour
{
    [SerializeField] float _pourDuration = 0.5f;

    [SerializeField] float _pourAngleLimit = 160f;

    [SerializeField] Vector2 _anchorPouringPosition = new(1.5f, 2f);

    private void OnPourBottle(Bottle source, Bottle target, int amount)
    {
        if (source == null || target == null ) return;

        if (_sequence.IsActive()) {
            _sequence.Complete();
            _sequence = DOTween.Sequence();
        } else
        {
            _sequence = DOTween.Sequence();
        }
        

        int absPoint = (target.OriginPosition.x - source.OriginPosition.x) > 0 ? -1 : 1;

        _sequence.Append(MoveBottleToPour(source, target, absPoint));

        _sequence.Append(StartPouringBottle(source, target, absPoint, amount));

        _sequence.Append(StopPouringBottle(source, target));

        _sequence.Append(MoveBottleToOrigin(source, target));


    }

    private Tween MoveBottleToPour(Bottle source, Bottle target, int absPoint)
    {
        Vector3 targetPosition = target.OriginPosition + new Vector3(_anchorPouringPosition.x * absPoint, _anchorPouringPosition.y);

        return source.transform.DOMove(targetPosition, _moveDuration);

    }

    private Tween StartPouringBottle(Bottle source, Bottle target, int absPoint, int amount)
    {
        Vector3 angle = absPoint * amount * new Vector3(0, 0, _pourAngleLimit) / source.WaterDepth;

        return source.transform.DORotate(angle, _pourDuration);

    }

    private Tween StopPouringBottle(Bottle source, Bottle target)
    {
        return source.transform.DORotate(Vector3.zero, _pourDuration);
    }
}


public partial class BottleAnimationHandler : MonoBehaviour
{
    [SerializeField] Vector3 _selectPosition = Vector3.up;

    private void OnSelectBottle(Bottle source)
    {
        if (source == null) return;

        if (_sequence.IsActive())
        {
            _sequence.Complete();
            _sequence = DOTween.Sequence();
        }
        else
        {
            _sequence = DOTween.Sequence();
        }

        MoveBottleToSelect(source);
    }

    private Tween MoveBottleToSelect(Bottle source)
    {
        return source.transform.DOMove(source.OriginPosition + _selectPosition, _moveDuration);
    }
}

public partial class BottleAnimationHandler : MonoBehaviour
{
    private void OnRemoveSelectBottle(Bottle source)
    {
        if (source == null) return;

        if (_sequence.IsActive())
        {
            _sequence.Complete();
            _sequence = DOTween.Sequence();
        }
        else
        {
            _sequence = DOTween.Sequence();
        }

        _sequence.Append(MoveBottleToOrigin(source));
        
    }
}



public partial class BottleAnimationHandler : MonoBehaviour
{
    private Tween MoveBottleToOrigin(Bottle source, Bottle target = null)
    {
        return source.transform.DOMove(source.OriginPosition, _moveDuration);
    }
}

