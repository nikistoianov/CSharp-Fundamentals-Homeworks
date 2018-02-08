using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var stack = new Stack<string>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "1")
                {
                    stack.Push(text.ToString());
                    text.Append(input[1]);
                }
                else if (input[0] == "2")
                {
                    stack.Push(text.ToString());
                    text.Length -= Math.Min(int.Parse(input[1]), text.Length);
                }
                else if (input[0] == "3")
                {
                    Console.WriteLine(text[int.Parse(input[1]) - 1]);
                }
                else if (input[0] == "4")
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }
        }
    }
}
