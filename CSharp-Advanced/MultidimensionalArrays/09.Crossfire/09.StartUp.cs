using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var jag = new int[sizes[0]][];
            FillJag(jag, sizes[1]);

            //PrintJag(jag);

            string command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                ShootJag(jag, command);
                CleanEmptyRows(ref jag);
                //Console.WriteLine();
                //PrintJag(jag);
                //Console.WriteLine();

                command = Console.ReadLine();
            }

            PrintJag(jag);
        }

        private static void ShootJag(int[][] jag, string command)
        {
            int[] cmd = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int radius = cmd[2];
            Point point = new Point(cmd[0], cmd[1]);
            point.RemoveFromJag(jag, 0, radius);
            for (int i = 1; i <= radius; i++)
            {
                point.RemoveFromJag(jag, i, 0);
                point.RemoveFromJag(jag, -i, 0);
            }
        }

        private static void FillJag(int[][] jag, int width)
        {
            int counter = 1;
            for (int i = 0; i < jag.Length; i++)
            {
                int[] arr = new int[width];
                for (int j = 0; j < width; j++)
                {
                    arr[j] = counter++;
                }
                jag[i] = arr;
            }
        }

        static void CleanEmptyRows(ref int[][] jag)
        {
            jag = jag.Where(x => x.Length != 0).ToArray();
        }
        
        static void PrintJag(int[][] jag)
        {
            for (int i = 0; i < jag.Length; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                {
                    Console.Write(jag[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

    }

    class Point
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Point(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool IsInsideJag(int[][] jag)
        {
            if (Row >= 0 && Row < jag.Length && Col >= 0 && Col < jag[Row].Length)
            {
                return true;
            }
            return false;
        }

        public Point ClonePoint(int rowIncrement, int colIncrement)
        {
            return new Point(Row + rowIncrement, Col + colIncrement);
        }

        public int GetPointVal(int[][] jag)
        {
            return jag[Row][Col];
        }

        public void RemoveFromJag(int[][] jag, int rowIncrement, int colIncrement)
        {
            int iRow = Row + rowIncrement;
            if (iRow < 0 || iRow >= jag.Length || Col - colIncrement >= jag[iRow].Length || Col + colIncrement < 0)
            {
                return;
            }

            var list = jag[iRow].ToList();
            int minId = Math.Max(Col - colIncrement, 0);
            int maxId = Math.Min(Col + colIncrement, jag[iRow].Length - 1);
            list.RemoveRange(minId, maxId - minId + 1);

            jag[iRow] = list.ToArray();

            //if (list.Count == 0)
            //{
            //    var newJag = jag.ToList();
            //    newJag.RemoveAt(iRow);
            //    jag = newJag.ToArray();
            //}
            
        }
    }
}
