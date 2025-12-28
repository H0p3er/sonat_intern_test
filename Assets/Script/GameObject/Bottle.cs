using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bottle : MonoBehaviour, IEquatable<Bottle>
{

    [SerializeField] int _waterDepth = 4;

    public int WaterDepth { get => _waterDepth; }
    public Stack<Water> WaterStack { get; private set; }

    public bool IsComplete {
        get
        {           

            bool isCompleteFlag = true;

            List<Water> waterList = WaterStack.ToList();

            for (int i = 0; i < waterList.Count - 1; i++)
            {
                if (!waterList[i].Equals(waterList[i + 1])) return false;
            }

            return isCompleteFlag;
        }
    
    }

    public bool IsFull => _waterDepth <= WaterStack.Count;

    private void Awake()
    {
        WaterStack = new Stack<Water>(_waterDepth);
    }

    public void SetWaterStackFromList(List<Water> waterList)
    {
        int count = Mathf.Min(WaterDepth, waterList.Count);

        for (int i = count - 1; i >= 0; i--)
        {
            WaterStack.Push(waterList[i]);
        }

    }

    public bool Equals(Bottle other)
    {

        if (other == null) return false;

        return this.GetInstanceID() == other.GetInstanceID();
    }
}
