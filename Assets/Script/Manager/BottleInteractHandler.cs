
using UnityEngine;

public partial class BottleInteractHandler : MonoBehaviour
{
    [SerializeField] Bottle _currentBottle;

    [SerializeField] Vector2 _mousePosition;

    private void OnEnable()
    {
        InputEvent.Point += OnPoint;
        InputEvent.Click += OnClick;
    }


    private void OnDisable()
    {
        InputEvent.Point -= OnPoint;
        InputEvent.Click -= OnClick;
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

        if (IsSelectable(_currentBottle, selectBottle)) {
            Debug.Log("Selecteable");
            Select(selectBottle);
            return;
        } 
        
        
        if (IsPourable(_currentBottle, selectBottle))
        {
            Debug.Log("Pourable");
            Pour(_currentBottle, selectBottle);
            _currentBottle = null;
            return;
        }

        
    }



    public enum State
    {
        Idle,
        Start,
        Running,
        Stop,
    }
}

public partial class BottleInteractHandler
{
    public void Pour(Bottle sourceBottle, Bottle targetBottle)
    {      
        int i = 0;

        while (IsPourable(sourceBottle, targetBottle))
        {
            i++;
            targetBottle.WaterStack.Push(sourceBottle.WaterStack.Pop());
        }

        ActionEvent.InvokePourBottle(sourceBottle, targetBottle, i);
    }

    public bool IsPourable(in Bottle sourceBottle, in Bottle targetBottle)
    {
        if (sourceBottle == null || targetBottle == null || sourceBottle.Equals(targetBottle))
        {
            Debug.Log("Target is null");
            return false;
        }

        if (targetBottle.IsFull)
        {
            Debug.Log("Target is full:");
            return false;
        }

        if (!sourceBottle.WaterStack.TryPeek(out Water soureFirstElement))
        {
            Debug.Log("Source is empty:");
            return false;
        }

        if (targetBottle.WaterStack.TryPeek(out Water targetFirstElement) && !soureFirstElement.Equals(targetFirstElement))
        {
            Debug.Log("Source is not Equal Target:");
            return false;
        }
        return true;

    }
}

public partial class BottleInteractHandler
{
    public void Select(Bottle bottle)
    {
        _currentBottle = bottle;
    }

    public void RemoveSelect() { 
        _currentBottle = null;    
    }

    public bool IsSelectable(Bottle sourceBottle, Bottle targetBottle)
    {

        if (targetBottle == null) return false;

        if (sourceBottle != null) return false;

        if (targetBottle.Equals(sourceBottle)) return false;

        return true;
    }
}

public partial class BottleInteractHandler
{
    private bool TryGetBottleByRaycast(out Bottle bottle)
    {
        bottle = default;

        Vector2 screenToWorldPoint = Camera.main.ScreenToWorldPoint(_mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(screenToWorldPoint, Vector2.zero);

        if (hit.collider == null) return false;

        return hit.collider.gameObject.TryGetComponent(out bottle);
    }


}