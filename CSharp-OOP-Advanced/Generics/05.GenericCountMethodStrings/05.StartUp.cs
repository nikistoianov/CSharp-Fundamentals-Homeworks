using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main()
        {
            var list = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                //var box = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(Console.ReadLine());
            }

            string input = Console.ReadLine();
            int result = Compare(list, input);
            Console.WriteLine(result);
        }

        public static int Compare<T>(List<T> list, string compareStr)
            where T : IComparable
        {
            int cntr = 0;

            foreach (T item in list)
            {
                if (item.CompareTo(compareStr) > 0)
                {
                    cntr++;
                }
            }

            return cntr;
        }
    }
}
