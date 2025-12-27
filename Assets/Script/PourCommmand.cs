
using UnityEngine;

public class PourCommmand
{
    private Bottle source;

    private Bottle target;

    public PourCommmand(Bottle source, Bottle target)
    {
        this.source = source;
        this.target = target;
    }

    public void Execute()
    {
        while (IsPourable(source, target))
        {
            target.Waters.Push(source.Waters.Pop());
        }
    }

    private bool IsPourable(Bottle source, Bottle target)
    {
        if (target.IsFull)
        {
            Debug.Log("Target is full:");
            return false;
        }

        if (!source.Waters.TryPeek(out Water soureFirstElement))
        {
            Debug.Log("Source is empty:");
            return false;
        }

        if (!target.IsEmpty && !soureFirstElement.Equals(target.Waters.Peek()))
        {
            Debug.Log("Source is not Equal Target:");
            return false;
        }
      
        return true;
    }

}

