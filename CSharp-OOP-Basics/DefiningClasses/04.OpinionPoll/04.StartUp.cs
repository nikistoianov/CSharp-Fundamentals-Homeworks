using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var people = new SortedDictionary<string, Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var person = new Person(Console.ReadLine());
            if (person.Age > 30)
            {
                people[person.Name] = person;
            }
        }

        foreach (var person in people)
        {
            Console.WriteLine(person.Value.ToString()); 
        }
    }
}
