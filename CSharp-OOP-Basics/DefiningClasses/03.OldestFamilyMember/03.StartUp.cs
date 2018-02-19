using System;

class Program
{
    static void Main()
    {
        var people = new Family();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var person = new Person(Console.ReadLine());
            people.AddMember(person);
        }
        Console.WriteLine(people.GetOldestMember());
    }
}

