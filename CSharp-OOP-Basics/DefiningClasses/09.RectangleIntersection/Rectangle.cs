using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double X1 { get; }
    public double Y1 { get; }

    public Rectangle(string rectangleLine)
    {
        var args = rectangleLine.Split();
        Id = args[0];
        Width = double.Parse(args[1]);
        Height = double.Parse(args[2]);
        X = double.Parse(args[3]);
        Y = double.Parse(args[4]);
        X1 = X + Width;
        Y1 = Y + Height;
    }

    public bool IntersectsWith(Rectangle otherRectangle)
    {
        //var x1 = otherRectangle.X;
        //var y1 = otherRectangle.Y;
        //var x2 = otherRectangle.X + otherRectangle.Width;
        //var y2 = otherRectangle.Y + otherRectangle.Height;
        //return (InsidePoint(x1, y1) || InsidePoint(x1, y2) || InsidePoint(x2, y2) || InsidePoint(x2, y1));
        return X <= otherRectangle.X1 && X1 >= otherRectangle.X && Y <= otherRectangle.Y1 && Y1 >= otherRectangle.Y;
    }

    public bool InsidePoint(double x, double y)
    {
        return (x >= X && x <= X + Width && y >= Y && y <= Y + Height);
    }
}
