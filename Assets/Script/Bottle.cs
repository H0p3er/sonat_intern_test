using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static UnityEditor.Progress;

public partial class Bottle : MonoBehaviour
{
    [SerializeField] int waterDepth = 4;

    public int WaterDepth { get => waterDepth; }
    public Stack<Water> Waters { get; private set; }

    private void Awake()
    {
        Waters = new Stack<Water>(waterDepth);
        _water = new List<Water>();
        GetWaterUI();
    }

    public bool IsFull => waterDepth == Waters.Count;


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

public partial class Bottle
{
    [SerializeField] List<Water> _water;


    public void DebugBottle()
    {
        StringBuilder stringBuilder = new StringBuilder();


        foreach (var item in Waters)
        {
            stringBuilder.AppendLine(name + ":" + item.ToString());
        }

        Debug.Log(stringBuilder.ToString());
    }

#if UNITY_EDITOR
    public void Start()
    {
        SyncFromList();
    }

    private void SyncFromStack()
    {
        Waters.Clear();
        foreach (var item in Waters)
        {
            _water.Add(item);
        }
    }

    private void SyncFromList()
    {
        foreach (var item in _water)
        {
            Waters.Push(item);
        }
    }

    private void FixedUpdate()
    {
        SyncFromStack();
    }
#endif
}
