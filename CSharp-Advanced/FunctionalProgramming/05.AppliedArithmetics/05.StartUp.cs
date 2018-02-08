using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            

            while (command != "end")
            {
                if (command == "print")
                    Console.WriteLine(string.Join(" ", nums));
                else
                    nums = nums.Select(GetCommand(command)).ToArray();
                command = Console.ReadLine();
            }
        }

        static Func<int, int> GetCommand(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    throw new NotImplementedException();
            }
            //Func<int, int> add = x => x + 1;
            //Func<int, int> multiply = x => x * 2;
            //Func<int, int> subtract = x => x - 1;
        }
    }
}
