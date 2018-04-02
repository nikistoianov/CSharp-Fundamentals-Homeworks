using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var args = input.Split().Skip(1).ToList();
        var list = new ListyIterator<string>(args);
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}