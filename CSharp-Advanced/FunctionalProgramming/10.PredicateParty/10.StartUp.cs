using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main()
        {
            var people = new List<string>(Console.ReadLine().Split());

            string commandLine;
            while ((commandLine = Console.ReadLine()) != "Party!")
                ApplyCommand(ref people, commandLine);

            if (people.Count == 0)
                Console.WriteLine("Nobody is going to the party!");
            else
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
        }

        private static void ApplyCommand(ref List<string> people, string commandLine)
        {
            var tokens = commandLine.Split();
            var command = tokens[0];
            var criteria = tokens[1];
            var criteriaParam = tokens[2];
            //var filter = GetFilter(command, criteria, criteriaParam);
            var filter = GetPeopleFilter(criteria, criteriaParam);
            //List<string> result = new List<string>();

            if (command == "Remove")
            {
                people = people.Where(filter).ToList();
            }
            else if (command == "Double")
            {
                var doubleFilter = DoublePeople(criteria, criteriaParam);
                people = doubleFilter(people);
            }

            //people = filter(people);
        }

        static Func<string, bool> GetPeopleFilter(string criteria, string criteriaParam)
        {
            return x =>
            {
                switch (criteria)
                {
                    case "StartsWith":
                        return !x.StartsWith(criteriaParam);
                    case "EndsWith":
                        return !x.EndsWith(criteriaParam);
                    case "Length":
                        return x.Length != int.Parse(criteriaParam);
                    default:
                        throw new NotImplementedException();
                }
            };
        }

        static Func<List<string>, List<string>> DoublePeople(string criteria, string criteriaParam)
        {
            return people =>
            {
                var filter = GetPeopleFilter(criteria, criteriaParam);
                // count = people.Count;
                for (int i = 0; i < people.Count; i++)
                {
                    var match = !filter(people[i]);
                    if (match)
                    {
                        people.Insert(i, people[i++]);
                    }
                }
                return people;
            };
        }
    }
}
