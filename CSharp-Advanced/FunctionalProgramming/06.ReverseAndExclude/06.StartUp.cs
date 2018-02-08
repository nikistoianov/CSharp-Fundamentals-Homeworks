using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());
            Func<int, bool> check (int number) { return x => x % number != 0; };
            var result = arr.Reverse().Where(check(num)).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
