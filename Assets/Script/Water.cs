using System;
using System.Runtime.Serialization;
using UnityEngine;


[Serializable]
public class Water : IEquatable<Water>
{
    public int id;
    public string name;
    public Color color;

    public bool Equals(Water other)
    {
        return this.id == other.id;
    }
}
