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

    public Color Color { get => GetColorFromEnum();}

    public bool Equals(Water other)
    {
        return this._color == other._color;
    }

    public enum WaterColor
    {
        Yellow,
        DarkGreen,
        Orange,
        Purple,
        Pink,
    }

    private Color GetColorFromEnum()
    {
        Color color;

        switch (_color)
        {
            case WaterColor.Yellow:
                color = Color.yellowNice;
                break;
            case WaterColor.DarkGreen:
                color = Color.darkGreen;
                break;
            case WaterColor.Orange:
                color = Color.orange;
                break;
            case WaterColor.Purple:
                color = Color.purple;
                break;
            case WaterColor.Pink:
                color = Color.deepPink;
                break;
            default:
                color = Color.clear;
                break;
        }

        return color;
    }
}


