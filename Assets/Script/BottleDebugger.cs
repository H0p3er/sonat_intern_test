using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BottleDebugger : MonoBehaviour
{
    [SerializeField] List<Water> _waterList = new ();

    [SerializeField] Bottle _bottle;

    Stack<Water> _waterStack;

    private void Awake()
    {
        if (TryGetComponent(out Bottle bottle)) { 
            _bottle = bottle;        
        } 
    }

    public void DebugBottle()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(name + ":");

        foreach (var item in _waterStack)
        {
            stringBuilder.Append(item.Color + ";");
        }

        Debug.Log(stringBuilder.ToString());
    }

#if UNITY_EDITOR
    public void Start()
    {
        _waterStack = _bottle.WaterStack;

        SyncFromList();

        DebugBottle();
    }

    private void SyncFromList()
    {
        foreach (var item in _waterList)
        {
/*            Debug.Log("Is Push:" + item.color);*/
            _waterStack.Push(item);
        }
    }

    private void SyncFromStack()
    {
        if (_waterStack == null) return;

/*        Debug.Log("Sync:");
*/
        _waterList.Clear();
        foreach (var item in _waterStack)
        {
            _waterList.Add(item);
        }
    }



    private void FixedUpdate()
    {
        SyncFromStack();
    }
#endif
}
