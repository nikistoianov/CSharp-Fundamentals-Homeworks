using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MaximumElement
{
    class Program
    {
        static void Main()
        {
            Stack<int> allStack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();

            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string query = Console.ReadLine();

                if (query.StartsWith("1"))
                {
                    int newElem = int.Parse(query.Substring(2));
                    allStack.Push(newElem);
                    if (maxStack.Count == 0 || newElem >= maxStack.Peek())
                    {
                        maxStack.Push(newElem);
                    }
                }
                else if (query == "2")
                {
                    int delElem = allStack.Pop();
                    if (delElem == maxStack.Peek())
                    {
                        maxStack.Pop();
                    }
                }
                else if (query == "3")
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}
