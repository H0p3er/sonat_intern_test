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
        GetWaterUI();
    }

    public bool IsFull => waterDepth <= Waters.Count;

    public bool IsEmpty => Waters.Count <= 0;
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
    [SerializeField] List<Water> _water = new ();


    public void DebugBottle()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(name + ":");

        foreach (var item in Waters)
        {
            stringBuilder.AppendLine(item.name + ":" + item.color);
        }

        Debug.Log(stringBuilder.ToString());
    }

#if UNITY_EDITOR
    public void Start()
    {
        SyncFromList();
        DebugBottle();
    }

    private void SyncFromList()
    {
        foreach (var item in _water)
        {
/*            Debug.Log("Is Push:" + item.color);*/
            Waters.Push(item);
        }
    }

    private void SyncFromStack()
    {
        if (Waters == null) return;

/*        Debug.Log("Sync:");
*/
        _water.Clear();
        foreach (var item in Waters)
        {
            _water.Add(item);
        }
    }



    private void FixedUpdate()
    {
        SyncFromStack();
    }
#endif
}
