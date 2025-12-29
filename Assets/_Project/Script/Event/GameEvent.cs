using UnityEngine.Events;


public static class GameEvent
{
    public static event UnityAction Win = delegate { };

    public static event UnityAction Lose = delegate { };

    public static void InvokeWin()
    {
        Win?.Invoke();
    }

    public static void InvokeClick()
    {
        Lose?.Invoke();
    }

}

