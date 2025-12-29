using UnityEngine.Events;
/// <summary>
/// Action Event Bus
/// </summary>
public static class GameActionEvent
{
    public static event UnityAction<Bottle> SelectBottle = delegate { };

    public static event UnityAction<Bottle> RemoveSelectBottle = delegate { };

    public static event UnityAction<Bottle, Bottle, int> PourBottle = delegate { };
    

    public static void InvokeSelectBottle(Bottle target)
    {
        SelectBottle?.Invoke(target);
    }

    public static void InvokeRemoveSelectBottle(Bottle target)
    {
        RemoveSelectBottle?.Invoke(target);
    }

    public static void InvokePourBottle(Bottle source, Bottle target, int amount)
    {
        PourBottle?.Invoke(source, target, amount);
    }
}

