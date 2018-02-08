using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            Console.Write(num + " ");
            long baseNum = num;

            int counter = 1;
            while (counter < 50)
            {
                counter++;
                queue.Enqueue(baseNum + 1);
                Console.Write(baseNum + 1 + " ");

                counter++;
                if (counter < 50)
                {
                    queue.Enqueue(2 * baseNum + 1);
                    Console.Write(2 * baseNum + 1 + " ");
                }

                counter++;
                if (counter < 50)
                {
                    queue.Enqueue(baseNum + 2);
                    Console.Write(baseNum + 2 + " ");
                }

                baseNum = queue.Dequeue();

            }
        }
    }
}
