using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public string Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Rectangle(string rectangleLine)
    {
        var args = rectangleLine.Split();
        Id = args[0];
        Width = int.Parse(args[1]);
        Height = int.Parse(args[2]);
        X = int.Parse(args[3]);
        Y = int.Parse(args[4]);
    }

    public bool IntersectsWith(Rectangle otherRectangle)
    {
        var x1 = otherRectangle.X;
        var y1 = otherRectangle.Y;
        var x2 = otherRectangle.X + otherRectangle.Width;
        var y2 = otherRectangle.Y + otherRectangle.Height;
        return (InsidePoint(x1, y1) || InsidePoint(x1, y2) || InsidePoint(x2, y2) || InsidePoint(x2, y1));
    }

    public bool InsidePoint(int x, int y)
    {
        return (x >= X && x <= X + Width && y >= Y && y <= Y + Height);
    }
}
