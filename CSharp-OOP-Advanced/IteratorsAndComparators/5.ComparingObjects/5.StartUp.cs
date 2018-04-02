using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
    class Program
    {
        static void Main()
        {
            var people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split();
                var person = new Person(args[0], int.Parse(args[1]), args[2]);
                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            int br = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(people[index]) == 0)
                {
                    br++;
                }
            }

            if (br > 1)
            {
                Console.WriteLine($"{br} {people.Count - br} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
