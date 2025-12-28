
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BottleSpawnDataSO", menuName = "Scriptable Objects/BottleSpawnDataSO")]
public class BottleSpawnDataSO : ScriptableObject
{
    public int numberOfBottles;

    public int numberPerRow;

    public int waterDepth;

    public List<BottleData> bottles = new ();

    private void Awake()
    {
        bottles.Capacity = numberOfBottles;
    }


}



[Serializable]
public class BottleData
{
    public List<Water> water = new ();

}