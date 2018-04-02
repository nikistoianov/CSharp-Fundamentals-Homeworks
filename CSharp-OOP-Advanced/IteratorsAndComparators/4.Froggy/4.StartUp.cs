using System;
using System.Linq;

namespace _4.Froggy
{
    class Program
    {
        static void Main()
        {
            var stones = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var lake = new Lake(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
