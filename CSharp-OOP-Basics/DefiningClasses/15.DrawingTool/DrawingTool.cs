using System;
using System.Collections.Generic;
using System.Text;

public class DrawingTool
{
    public string Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public DrawingTool(string type, int width, int height)
    {
        Type = type;
        Width = width;
        Height = height;
    }

    public void Draw()
    {
        for (int i = 1; i <= Height; i++)
        {
            Console.WriteLine($"|{new string((i == 1 || i == Height) ? '-' : ' ', Width)}|");
        }
    }
}