using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public partial class Bottle : MonoBehaviour
{
    public int waterDepth = 4;

    public Stack<Water> waters;

    private void Awake()
    {
        waters = new Stack<Water>(waterDepth);

        GetWaterUI();
    }

    public bool IsFull => waterDepth == waters.Count;
}

public partial class Bottle
{
    public Material material;

    private void GetWaterUI()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        if (spriteRenderer != null) material = spriteRenderer.material;
    }
}


public class PourCommmand
{
    public Bottle source;

    public Bottle target;

    public void Execute()
    {

        while (IsPourable(source, target))
        {
            target.waters.Push(source.waters.Pop());
        }
    }

    private bool IsPourable(Bottle source, Bottle target)
    {
        bool isNotPourableCondition = target.IsFull
            || !source.waters.TryPeek(out Water soureFirstElement)
            || !soureFirstElement.Equals(target.waters.Peek());

        return !isNotPourableCondition;
    }

}

