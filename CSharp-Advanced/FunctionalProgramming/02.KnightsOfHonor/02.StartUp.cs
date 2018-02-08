using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();
            Action<string> print = x => Console.WriteLine($"Sir {x}");
            foreach (var line in names)
            {
                print(line);
            }
        }
    }
}
