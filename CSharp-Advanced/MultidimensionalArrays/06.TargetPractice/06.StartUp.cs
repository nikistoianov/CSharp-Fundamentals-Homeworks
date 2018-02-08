using System;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int[] inpact = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var matrix = new string[sizes[0], sizes[1]];
            FillMatrixWithSnake(matrix, input);
            ShootMatrix(matrix, inpact[1], inpact[0], inpact[2]);
            FallChars(matrix);
            PrintMatrix(matrix);
        }

        static void FillMatrixWithSnake(string[,] matrix, string snakeString)
        {
            int rowCount = 0, allCount = 0;
            char[] snake = snakeString.ToCharArray();
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (rowCount % 2 == 0)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[allCount++ % snake.Length].ToString();
                    }
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[allCount++ % snake.Length].ToString();
                    }
                }
                rowCount++;
            }
        }

        static void ShootMatrix(string[,] matrix, int c, int r, int radius)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Distance(i, r, j, c) <= radius)
                    {
                        matrix[i, j] = " ";
                    }
                }
            }
        }

        static double Distance(int x1, int x2, int y1, int y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        static void ShootMatrix_old(string[,] matrix, int c, int r, int radius)
        {
            int count = 0;
            for (int i = r; i <= r + radius; i++)
            {
                for (int j = c - radius + count; j <= c + radius - count; j++)
                {
                    if (CheckPointIn(matrix, i, j))
                    {
                        matrix[i, j] = " ";
                    }
                    if (CheckPointIn(matrix, i - count * 2, j))
                    {
                        matrix[i - count * 2, j] = " ";
                    }
                }
                count++;
            }
        }

        static bool CheckPointIn(string[,] matrix, int r, int c)
        {
            if (r >=0 && r < matrix.GetLength(0) && c >= 0 && c < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static void FallChars(string[,] matrix)
        {
            for (int i = matrix.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == " ")
                    {
                        FallChar(matrix, i, j);
                    }
                }
            }
        }

        static void FallChar(string[,] matrix, int r, int c)
        {
            for (int i = r - 1; i >= 0; i--)
            {
                if (matrix[i, c] != " ")
                {
                    matrix[r, c] = matrix[i, c];
                    matrix[i, c] = " ";
                    break;
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
