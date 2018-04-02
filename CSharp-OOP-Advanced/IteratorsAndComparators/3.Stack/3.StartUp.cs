using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var stack = new Stack<string>();
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                if (command.StartsWith("Pop"))
                {
                    stack.Pop();
                }
                else if (command.StartsWith("Push"))
                {
                    var args = command.Substring(5).Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < args.Length; i++)
                    {
                        stack.Push(args[i]);
                    }
                }                
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
        for (int i = 0; i < 2; i++)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }        
    }
}
