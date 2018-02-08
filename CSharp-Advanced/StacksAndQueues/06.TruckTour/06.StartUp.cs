using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPumps = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numPumps; i++)
            {
                int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(pump[0] - pump[1]);
            }

            for (int startPump = 0; startPump < numPumps; startPump++)
            {
                int totalFuel = 0;
                bool circleClosed = true;

                for (int currentPump = 0; currentPump < numPumps - 1; currentPump++)
                {
                    int currentFuel = queue.Dequeue();
                    totalFuel += currentFuel;
                    queue.Enqueue(currentFuel);

                    if (totalFuel < 0)
                    {
                        circleClosed = false;
                        startPump += currentPump;
                        break;
                    }
                }

                if (circleClosed)
                {
                    Console.WriteLine(startPump);
                    Environment.Exit(0);
                }
            }
        }
    }
}
