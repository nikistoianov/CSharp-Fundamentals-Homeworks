using System;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[sizes[0], sizes[1]];
            int counter = 0;

            for (int i = 0; i < sizes[0]; i++)
            {
                for (int j = 0; j < sizes[1]; j++)
                {
                    matrix[i, j] = ++counter;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                FlipRubic(matrix, input[1], int.Parse(input[0]), int.Parse(input[2]));
            }

            counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ++counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        Console.WriteLine(FindNumInAndSwap(matrix, i, j, counter));
                    }
                }
            }
            
        }

        static void FlipRubic(int[,] matrix, string direction, int index, int number)
        {
            int firstVal = 0;
            switch (direction)
            {
                case "up":
                    for (int i = 0; i < number % matrix.GetLength(0); i++)
                    {
                        firstVal = matrix[0, index];
                        for (int r = 0; r < matrix.GetLength(0) - 1; r++)
                        {
                            matrix[r, index] = matrix[r + 1, index];
                        }
                        matrix[matrix.GetLength(0) - 1, index] = firstVal;
                    }
                    break;
                case "down":
                    for (int i = 0; i < number % matrix.GetLength(0); i++)
                    {
                        firstVal = matrix[matrix.GetLength(0) - 1, index];
                        for (int r = matrix.GetLength(0) - 1; r > 0; r--)
                        {
                            matrix[r, index] = matrix[r - 1, index];
                        }
                        matrix[0, index] = firstVal;
                    }
                    break;
                case "left":
                    for (int i = 0; i < number % matrix.GetLength(1); i++)
                    {
                        firstVal = matrix[index, 0];
                        for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                        {
                            matrix[index, c] = matrix[index, c + 1];
                        }
                        matrix[index, matrix.GetLength(1) - 1] = firstVal;
                    }
                    break;
                case "right":
                    for (int i = 0; i < number % matrix.GetLength(1); i++)
                    {
                        firstVal = matrix[index, matrix.GetLength(1) - 1];
                        for (int c = matrix.GetLength(1) - 1; c > 0; c--)
                        {
                            matrix[index, c] = matrix[index, c - 1];
                        }
                        matrix[index, 0] = firstVal;
                    }
                    break;
            }
        }

        static string FindNumInAndSwap(int[,] matrix, int x, int y, int num)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == num)
                    {
                        matrix[i, j] = matrix[x, y];
                        matrix[x, y] = num;
                        return $"Swap ({x}, {y}) with ({i}, {j})";
                    }
                }
            }
            return "";
        }
        
    }
}
