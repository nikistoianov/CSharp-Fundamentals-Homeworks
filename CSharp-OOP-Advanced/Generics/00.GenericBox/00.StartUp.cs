using System;

namespace _00.GenericBox
{
    class Program
    {
        static void Main()
        {
            var box = new Box<string>("life in a box");
            Console.WriteLine(box);

            var box2 = new Box<int>(123123);
            Console.WriteLine(box2);
        }
    }
}
