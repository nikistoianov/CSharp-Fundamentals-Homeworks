using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacciWithStack(num));
        }

        private static long GetFibonacciWithStack(int num)
        {
            var stack = new Stack<long>(new long[]{0, 1});
            for (int i = 1; i < num; i++)
            {
                long firstNum = stack.Pop(), secondNum = stack.Pop();
                stack.Push(firstNum);
                stack.Push(firstNum + secondNum);
            }
            return stack.Peek();
        }
    }
}
