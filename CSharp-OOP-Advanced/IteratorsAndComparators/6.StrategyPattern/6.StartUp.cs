using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.StrategyPattern
{
    class Program
    {
        static void Main()
        {
            var nameSet = new SortedSet<Person>(new NameComparator());
            var ageSet = new SortedSet<Person>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();
                var person = new Person(args[0], int.Parse(args[1]));
                nameSet.Add(person);
                ageSet.Add(person);
            }

            foreach (var person in nameSet)
            {
                Console.WriteLine(person);
            }

            foreach (var person in ageSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}
