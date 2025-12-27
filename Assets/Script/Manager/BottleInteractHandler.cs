using JetBrains.Annotations;
using System;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleInteractHandler : MonoBehaviour
{
    [SerializeField] Bottle _currentBottle;

    [SerializeField] Vector2 _mousePosition;

    private void OnEnable()
    {
        GameEvent.Point += OnPoint;
        GameEvent.Click += OnClick;
    }


    private void OnDisable()
    {
        GameEvent.Point -= OnPoint;
        GameEvent.Click -= OnClick;
    }

    private void OnPoint(Vector2 vector)
    {
/*        Debug.Log("Mouse position" + vector);*/
        _mousePosition = vector;
    }


    private void OnClick()
    {

        if (!TryGetBottleByRaycast(out Bottle selectBottle)) {       
            Debug.Log("Not found Bottle");
            _currentBottle = null;
            return;
        }

        if (selectBottle.Equals(_currentBottle)) { // Prevent Duplicate select
            return;
        }


        if (_currentBottle != null) { // Check whether to select or pour 

            var pourCommmand = new PourCommmand(_currentBottle, selectBottle);

            pourCommmand.Execute();

            _currentBottle = null;

            return;
        } 

        _currentBottle = selectBottle;

    }

    private bool TryGetBottleByRaycast(out Bottle bottle)
    {
        bottle = default;

        Vector2 screenToWorldPoint = Camera.main.ScreenToWorldPoint(_mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(screenToWorldPoint, Vector2.zero);

        if (hit.collider == null) return false;

        return hit.collider.gameObject.TryGetComponent(out bottle);
    }
}
