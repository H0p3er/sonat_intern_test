using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public partial class Bottle : MonoBehaviour
{
    public int waterDepth = 4;

    public Stack<Water> waters;

    public bool IsFull => waterDepth == waters.Count;
}

public class PourCommmand
{
    public Bottle source;

    public Bottle target;

    public void Execute()
    {
        Pour(source, target);
    }

    private bool IsPourable(Bottle source, Bottle target)
    {
        return target.IsFull
            || !source.waters.TryPeek(out Water soureFirstElement)
            || !soureFirstElement.Equals(target.waters.Peek()); ;
    }

    private void Pour(Bottle source, Bottle target) { 
    
        while (IsPourable(source, target))
        {
            target.waters.Push(source.waters.Pop());
        }
    }
}

