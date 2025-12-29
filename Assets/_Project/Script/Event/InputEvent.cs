using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Input Event Bus
/// </summary>
public static class InputEvent
{
    public static event UnityAction<Vector2> Point = delegate { };

    public static event UnityAction Click = delegate { };

    public static void InvokePoint(Vector2 point) { 
        Point?.Invoke(point);
    }

    public static void InvokeClick()
    {
        Click?.Invoke();
    }

}

