using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var fib = new long[num];
            Console.WriteLine(GetFibonacci(num, fib));
        }

        static long GetFibonacci(int num, long[] fib)
        {
            if (num < 3)
            {
                return 1;
            }

            if (fib[num - 1] == 0)
            {
                fib[num - 1] = GetFibonacci(num - 1, fib);
            }

            if (fib[num - 2] == 0)
            {
                fib[num - 2] = GetFibonacci(num - 2, fib);
            }

            return fib[num - 1] + fib[num - 2];
        }
    }
}
