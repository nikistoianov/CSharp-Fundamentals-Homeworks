using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main()
        {
            var list = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(box);
            }

            var args = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SwapElements(list, args[0], args[1]);
            list.ForEach(x => Console.WriteLine(x));
        }

        public static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T val = list[secondIndex];
            list[secondIndex] = list[firstIndex];
            list[firstIndex] = val;
        }
    }
}
