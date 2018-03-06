using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var rectangles = new Dictionary<string, Rectangle>();
        var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < arr[0]; i++)
        {
            var rectangle = new Rectangle(Console.ReadLine());
            rectangles[rectangle.Id] = rectangle;
        }

        for (int i = 0; i < arr[1]; i++)
        {
            var ids = Console.ReadLine().Split();
            var intersects = rectangles[ids[0]].IntersectsWith(rectangles[ids[1]]);
            Console.WriteLine(intersects ? "true" : "false");
        }
    }
}
