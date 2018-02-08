using System;
using System.Collections.Generic;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main()
        {
            string rotate = Console.ReadLine();
            int degrees = int.Parse(rotate.Substring(7, rotate.Length - 8)) % 360;
            string input = Console.ReadLine();
            int max = input.Length;
            var raw = new List<char[]>();

            while (input != "END")
            {
                var arr = input.ToCharArray();
                max = Math.Max(max, arr.Length);
                raw.Add(arr);

                input = Console.ReadLine();
            }

            var matrix = RotateRaw(raw, max, degrees);

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
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

        public static char[,] RotateRaw(List<char[]> raw, int cols, int degrees)
        {

            if (degrees == 0)
            {
                var matrix = new char[raw.Count, cols];
                for (int i = 0; i < raw.Count; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j < raw[i].Length)
                        {
                            matrix[i, j] = raw[i][j];
                        }
                        else
                        {
                            matrix[i, j] = ' ';
                        }
                    }
                }
                return matrix;
            }
            else if (degrees == 90)
            {
                var matrix = new char[cols, raw.Count];
                for (int i = 0; i < raw.Count; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int r = j;
                        int c = raw.Count - i - 1;
                        if (j < raw[i].Length)
                        {
                            matrix[r, c] = raw[i][j];
                        }
                        else
                        {
                            matrix[r, c] = ' ';
                        }
                    }
                }
                return matrix;
            }
            else if (degrees == 180)
            {
                var matrix = new char[raw.Count, cols];
                for (int i = 0; i < raw.Count; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int r = raw.Count - i - 1;
                        int c = cols - j - 1;
                        if (j < raw[i].Length)
                        {
                            matrix[r, c] = raw[i][j];
                        }
                        else
                        {
                            matrix[r, c] = ' ';
                        }
                    }
                }
                return matrix;
            }
            else if (degrees == 270)
            {
                var matrix = new char[cols, raw.Count];
                for (int i = 0; i < raw.Count; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int r = cols - j - 1;
                        int c = i;
                        if (j < raw[i].Length)
                        {
                            matrix[r, c] = raw[i][j];
                        }
                        else
                        {
                            matrix[r, c] = ' ';
                        }
                    }
                }
                return matrix;
            }

            return null;
        }
    }
}
