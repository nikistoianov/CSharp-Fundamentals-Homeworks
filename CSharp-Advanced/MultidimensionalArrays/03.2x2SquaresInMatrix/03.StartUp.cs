using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new char[sizes[0], sizes[1]];

            for (int i = 0; i < sizes[0]; i++)
            {
                char[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < sizes[1]; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            int counter = 0;
            for (int i = 0; i < sizes[0] - 1; i++)
            {
                for (int j = 0; j < sizes[1] - 1; j++)
                {
                    if (matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
