using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public int waterDepth = 4;

    public Stack<Water> _water;

    public List<SpriteRenderer> renderers;


    private void Awake()
    {
        Instantiate(gameObject);
    }


    public void OnPouring(Water water)
    {
        if (!IsPourable(water)) return;

        AddWater(water);
    }

    public void AddWater(Water water)
    {
        _water.Push(water);
    }

    public bool IsPourable(Water water)
    {
        if (_water.Count < waterDepth && _water.Count > 0) return true;

        if (_water.Peek().id == water.id) return true;

        return false;
    }

    public void RemoveWater(Water water)
    {
        int i = 0;
        while (i < _water.Count) {
         

            Water waterFromStack = _water.Pop();

            if (waterFromStack != null)
            {

            }

            i++;
        }
        
    }

}

public class BottleData
{
    public readonly int waterDepth = 4;

    public Stack<Water> water;

    public BottleData(int waterDepth = 4) {
        this.waterDepth = waterDepth;
        this.water = new(waterDepth);
    }

}