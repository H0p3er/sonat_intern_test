using UnityEngine;
using UnityEngine.Events;

public static class BottleEvent
{
    public static event UnityAction<Bottle> OnSelect = delegate { };

    public static event UnityAction OnPouring = delegate { };
}
