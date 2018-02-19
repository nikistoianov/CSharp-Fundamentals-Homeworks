using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var rectangulars = new Dictionary<string, Rectangle>();
        var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < arr[0]; i++)
        {
            var rectangular = new Rectangle(Console.ReadLine());
            rectangulars[rectangular.Id] = rectangular;
        }

        for (int i = 0; i < arr[1]; i++)
        {
            var ids = Console.ReadLine().Split();
            var intersects = rectangulars[ids[0]].IntersectsWith(rectangulars[ids[1]]);
            Console.WriteLine(intersects ? "true" : "false");
        }
    }
}
