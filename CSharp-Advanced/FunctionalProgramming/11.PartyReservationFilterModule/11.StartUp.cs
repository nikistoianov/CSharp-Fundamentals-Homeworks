using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main()
        {
            var people = new List<string>(Console.ReadLine().Split());

            var filters = new Dictionary<string, Func<List<string>, List<string>>>();

            string commandLine;
            while ((commandLine = Console.ReadLine()) != "Print")
                ParseCommand(commandLine, filters);

            List<string> filtered = GetFiltered(people, filters);
            var result = people.Where(person => !filtered.Contains(person)).ToList();
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<string> GetFiltered(List<string> people, Dictionary<string, Func<List<string>, List<string>>> filters)
        {
            var filtered = new List<string>();
            foreach (var pair in filters)
            {
                var filter = pair.Value;
                var currentFiltered = filter(people);
                filtered.AddRange(currentFiltered);
            }
            return filtered;
        }

        private static void ParseCommand(string commandLine, Dictionary<string, Func<List<string>, List<string>>> filters)
        {
            var tokens = commandLine.Split(';');
            var command = tokens[0];
            var filterType = tokens[1];
            var filterParam = tokens[2];
            var filterKey = $"{filterType} {filterParam}";

            if (command == "Add filter")
                filters[filterKey] = CreateFunction(filterType, filterParam);
            else
                filters.Remove(filterKey);
        }

        private static Func<List<string>, List<string>> CreateFunction(string filterType, string filterParam)
        {
            switch (filterType)
            {
                case "Starts with":
                    return people => people.Where(person =>
                    {
                        return person.StartsWith(filterParam);
                    }).ToList();
                case "Ends with":
                    return people => people.Where(person =>
                    {
                        return person.EndsWith(filterParam);
                    }).ToList();
                case "Length":
                    return people => people.Where(person =>
                    {
                        return person.Length == int.Parse(filterParam);
                    }).ToList();
                case "Contains":
                    return people => people.Where(person =>
                    {
                        return person.Contains(filterParam);
                    }).ToList();
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
