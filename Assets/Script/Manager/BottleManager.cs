using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleManager : MonoBehaviour
{
    [SerializeField] Bottle _selectedBottle;

    [SerializeField] Bottle _currentBottle;


    private void OnEnable()
    {
        InputManager.Instance.Click += OnClick;
    }

    private void OnDisable ()
    {
        InputManager.Instance.Click -= OnClick;
    }

    private void OnClick()
    {

        Debug.Log("On Click"); 
       
        Vector2 mousePosition = InputManager.Instance.MousePosition;

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider == null) return;

        if (!hit.collider.gameObject.TryGetComponent(out Bottle selectBottle)) return;

        selectBottle.DebugBottle();

        if (_selectedBottle == null) {
            _selectedBottle = selectBottle;
        } else
        {
            PourCommmand pourCommmand = new PourCommmand(_selectedBottle, _currentBottle);

            pourCommmand.Execute();

        }
    }
}
