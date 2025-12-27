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

/// <summary>
/// Animation Event Bus
/// </summary>
public static class AnimationEvent
{
    public static event UnityAction<Bottle> SelectBottle = delegate { };

    public static event UnityAction<Bottle, Bottle, int> PourBottle = delegate { };

    public static void InvokeSelectBottle(Bottle target)
    {
        SelectBottle?.Invoke(target);
    }

    public static void InvokePourBottle(Bottle source, Bottle target, int amount)
    {
        PourBottle?.Invoke(source, target, amount);
    }
}

