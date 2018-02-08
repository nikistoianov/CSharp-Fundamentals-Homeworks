using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
            var resultNums = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                resultNums.Add(i);
            }

            resultNums = resultNums.Where(GetPredicate(arr)).ToList();
            Console.WriteLine(string.Join(" ", resultNums));
        }

        static Func<int, bool> GetPredicate(int[] numbers)
        {
            return x =>
            {
                foreach (var number in numbers)
                {
                    if (x % number != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
