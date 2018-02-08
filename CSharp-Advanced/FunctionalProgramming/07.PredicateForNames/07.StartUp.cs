using System;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();
            var filter = GetFilter(num);

            foreach (var name in names)
            {
                if (filter(name))
                {
                    Console.WriteLine(name);
                }
            }

        }

        static Func<string, bool> GetFilter(int maxLength)
        {
            return x => x.Length <= maxLength;
        }
    }
}
