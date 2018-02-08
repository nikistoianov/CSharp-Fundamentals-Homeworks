using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class Program
    {
        static void Main()
        {
            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();

            var filters = new Dictionary<string, Func<List<int>, List<int>>>();

            string commandLine;
            while ((commandLine = Console.ReadLine()) != "Forge")
                ParseCommand(commandLine, filters);

            List<int> filtered = GetFiltered(gems, filters);
            var result = gems.Where(gem => !filtered.Contains(gem)).ToList();
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> GetFiltered(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            var filtered = new List<int>();
            foreach (var pair in filters)
            {
                var filter = pair.Value;
                var currentFiltered = filter(gems);
                filtered.AddRange(currentFiltered);
            }
            return filtered;
        }

        private static void ParseCommand(string commandLine, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            var tokens = commandLine.Split(';');
            var command = tokens[0];
            var filterType = tokens[1];
            var filterParam = int.Parse(tokens[2]);
            var filterKey = $"{filterType} {filterParam}";

            if (command == "Exclude")
            {
                filters[filterKey] = CreateFunction(filterType, filterParam);
            }
            else
            {
                filters.Remove(filterKey);
            }
        }

        private static Func<List<int>, List<int>> CreateFunction(string filterType, int filterParam)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return gems => gems.Where(gem =>
                    {
                        var index = gems.IndexOf(gem);
                        var leftGem = index > 0 ? gems[index - 1] : 0;
                        var result = gem + leftGem == filterParam;
                        return result;
                    }).ToList();
                case "Sum Right":
                    return gems => gems.Where(gem =>
                    {
                        var index = gems.IndexOf(gem);
                        var rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + rightGem == filterParam;
                    }).ToList();
                case "Sum Left Right":
                    return gems => gems.Where(gem =>
                    {
                        var index = gems.IndexOf(gem);
                        var leftGem = index > 0 ? gems[index - 1] : 0;
                        var rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + leftGem + rightGem == filterParam;
                    }).ToList();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
