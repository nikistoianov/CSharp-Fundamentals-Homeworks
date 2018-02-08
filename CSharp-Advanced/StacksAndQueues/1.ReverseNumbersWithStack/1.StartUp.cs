using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReverseNumbersWithStack
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(nums.Pop() + " ");
            }
        }
    }
}
