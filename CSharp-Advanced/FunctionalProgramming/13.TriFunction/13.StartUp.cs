using System;
using System.Linq;

namespace _13.TriFunction
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            var filter = CreateFilter(num);
            Console.WriteLine(names.FirstOrDefault(filter));

            //Func<string, int, bool> match = (name, length) => name.ToCharArray().Sum(x => x) >= length;
            //Console.WriteLine(names.FirstOrDefault(name => match(name, num)));
        }

        static Func<string, bool> CreateFilter(int length)
        {
            return name => name.ToCharArray().Sum(x => x) >= length;
        }
    }
}
