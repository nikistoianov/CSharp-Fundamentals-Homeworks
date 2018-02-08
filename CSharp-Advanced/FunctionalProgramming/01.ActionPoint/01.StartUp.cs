using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> print = x => Console.WriteLine(x);
            foreach (var line in input)
            {
                print(line);
            }
        }
    }
}
