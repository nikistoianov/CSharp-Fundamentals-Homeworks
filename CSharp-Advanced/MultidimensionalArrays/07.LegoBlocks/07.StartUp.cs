using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jag1 = new int[n][], jag2 = new int[n][];
            int[] widths = new int[n];
            bool match = true;

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                widths[i] = arr.Length;
                jag1[i] = arr;
            }

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
                widths[i] += arr.Length;
                jag2[i] = arr;
                if (i > 0 && match && widths[i] != widths[i - 1])
                {
                    match = false;
                }
            }

            if (match)
            {
                for (int i = 0; i < n; i++)
                {
                    PrintArray(jag1[i].Concat(jag2[i]).ToArray());
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {widths.Sum()}");
            }
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine($"[{String.Join(", ", arr)}]");
        }
    }
}
