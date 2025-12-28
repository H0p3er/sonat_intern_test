using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;


[Serializable]
public class Water : IEquatable<Water>
{
    [SerializeField] private WaterColor _color;

    public Water(WaterColor color)
    {
        this._color = color;
    }

    public Color Color {
        get
        {
            Color color;

            switch (_color)
            {
                case WaterColor.Red:
                    color = Color.red;
                    break;
                case WaterColor.Green:
                    color = Color.green;
                    break;
                case WaterColor.Blue:
                    color = Color.blue;
                    break;
                case WaterColor.Purple:
                    color = Color.purple;
                    break;
                default:
                    color = Color.clear;
                    break;
            }
            
            return color;
        }
    }

    public bool Equals(Water other)
    {
        return this._color == other._color;
    }

    public enum WaterColor
    {
        Red,
        Green,
        Blue,
        Purple,
    }

}


