using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] days = new int[plants.Length];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (stack.Count > 0 && plants[stack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stack.Pop()]);
                }
                if (stack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                stack.Push(i);
            }
            Console.WriteLine(days.Max());
        }

        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //    int days = 0;

        //    //var queue = new Queue<int>(arr);
        //    //int plantsCount = arr.Length;
        //    bool plantDies = true;

        //    //while (plantsCount > 1 && plantDies)
        //    //{
        //    //    plantDies = false;
        //    //    int count = plantsCount;
        //    //    for (int i = 0; i < count - 1; i++)
        //    //    {
        //    //        int pesticide = queue.Dequeue();
        //    //        if (pesticide > queue.Peek())
        //    //        {
        //    //            plantDies = true;
        //    //            plantsCount--;
        //    //        }
        //    //        else
        //    //        {
        //    //            queue.Enqueue(pesticide);
        //    //        }
        //    //    }
        //    //    queue.Enqueue(queue.Dequeue());
        //    //    if (plantDies) days++;
        //    //}

        //    var plants = new List<int>(arr);
        //    do
        //    {
        //        plantDies = CheckPlantDies(plants);
        //        if (plantDies) days++;
        //    } while (plantDies);

        //    Console.WriteLine(days);
        //}

        //static bool CheckPlantDies(List<int> plants)
        //{
        //    int elemCount = plants.Count;
        //    for (int i = elemCount - 1; i > 0; i--)
        //    {
        //        if (plants[i] > plants[i - 1])
        //        {
        //            plants.RemoveAt(i);
        //        }
        //    }
        //    return (plants.Count != elemCount);
        //}
    }
}
