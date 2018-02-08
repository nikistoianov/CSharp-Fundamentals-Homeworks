using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            
            for (int i = 0; i < size; i++)
            {
                int[] arr = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
            
            int sumMainDia = 0, sumSecondDia = 0;
            for (int i = 0; i < size; i++)
            {
                sumMainDia += matrix[i, i];
                sumSecondDia += matrix[i, size - i - 1];
            }

            Console.WriteLine(Math.Abs(sumMainDia - sumSecondDia));
        }
    }
}
