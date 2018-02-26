using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    private double Length
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    private double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            height = value;
        }
    }

    private double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Height = height;
        Width = width;
    }

    public double SurfaceArea()
    {
        return 2 * length * width + 2 * length * height + 2 * width * height;
    }

    public double LateralSurfaceArea()
    {
        return 2 * length * height + 2 * width * height;
    }

    public double Volume()
    {
        return length * width * height;
    }
}