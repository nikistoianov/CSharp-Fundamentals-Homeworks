using System;

class Program
{
    static void Main()
    {
        string type = Console.ReadLine();
        int width = int.Parse(Console.ReadLine());
        int height = width;
        if (type == "Rectangle")
        {
            height = int.Parse(Console.ReadLine());
        }

        var tool = new DrawingTool(type, width, height);
        tool.Draw();
    }
}
