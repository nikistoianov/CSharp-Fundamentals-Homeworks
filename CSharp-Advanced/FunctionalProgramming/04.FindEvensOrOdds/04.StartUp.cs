using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Predicate<int> isEven = x => x % 2 == 0;
            for (int i = nums[0]; i <= nums[1]; i++)
            {
                if ((command == "even" && isEven(i)) || (command == "odd" && !isEven(i)))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
