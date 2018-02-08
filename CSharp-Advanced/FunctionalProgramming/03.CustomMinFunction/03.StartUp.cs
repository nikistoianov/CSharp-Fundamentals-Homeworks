using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> min = x => x.OrderBy(y => y).ToArray()[0];
            Console.WriteLine(min(nums));
        }
    }
}
