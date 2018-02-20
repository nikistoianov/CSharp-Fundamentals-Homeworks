using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var people = new Dictionary<string, Person>();
        string commandLine;
        while ((commandLine = Console.ReadLine()) != "End")
        {
            var args = commandLine.Split();
            var personName = args[0];
            var command = args[1];
            var commandArgs = args.Skip(2).ToArray();

            if (!people.ContainsKey(personName))
            {
                var person = new Person(personName);
                people.Add(personName, person);
            }

            people[personName].ApplyInfo(command, commandArgs);
        }

        string name = Console.ReadLine();
        Console.WriteLine(people[name]);
    }
}
