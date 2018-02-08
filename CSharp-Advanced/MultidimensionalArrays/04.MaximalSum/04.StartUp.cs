using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                int[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < sizes[1]; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            int maxSum = int.MinValue, x = 0, y = 0;
            for (int i = 0; i < sizes[0] - 2; i++)
            {
                for (int j = 0; j < sizes[1] - 2; j++)
                {
                    int sum = matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j]
                              + matrix[i, j + 1] + matrix[i + 1, j + 1] + matrix[i + 2, j + 1]
                              + matrix[i, j + 2] + matrix[i + 1, j + 2] + matrix[i + 2, j + 2];
                    if (sum > maxSum)
                    {
                        x = i;
                        y = j;
                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(matrix, x, y, 3, 3);
        }

        static void PrintMatrix(int[,] matrix, int x, int y, int wi, int hi)
        {
            for (int i = x; i < Math.Min(matrix.GetLength(0), hi + x); i++)
            {
                for (int j = y; j < Math.Min(matrix.GetLength(1), wi + y); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
