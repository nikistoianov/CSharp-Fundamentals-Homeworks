using System;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]), cols = int.Parse(input[1]);
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var matrix = new string[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = alphabet[r].ToString() + alphabet[c + r].ToString() + alphabet[r].ToString();
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
