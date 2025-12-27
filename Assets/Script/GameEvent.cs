using UnityEngine;
using UnityEngine.Events;

public static partial class GameEvent
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

public static partial class GameEvent
{
    public static event UnityAction<AnimationState> SelectAnimation = delegate { };

    public static event UnityAction<AnimationState> PouringAnimation = delegate { };

    public static void InvokeSelectAnimation(AnimationState animationState)
    {
        SelectAnimation?.Invoke(animationState);
    }

}

public enum AnimationState
{
    Start,
    Running,
    Stop,
}
