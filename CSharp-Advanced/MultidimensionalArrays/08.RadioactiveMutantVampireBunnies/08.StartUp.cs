using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var jag = new char[sizes[0]][];
            for (int i = 0; i < sizes[0]; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                jag[i] = input;
            }
            char[] commands = Console.ReadLine().ToCharArray();
            Point player = GetPlayer(jag);
            string result = "";

            foreach (char command in commands)
            {
                result = MovePlayer(jag, ref player, command);
                SpreadBunnies(jag);
                if (result == "" && player.IsInsideJag(jag) && player.GetPointVal(jag) == 'B')
                {
                    result = "dead";
                }
                if (result != "")
                {
                    break;
                }

                //PrintJag(jag);
                //Console.WriteLine();
            }

            PrintJag(jag);
            Console.WriteLine($"{result}: {player.Row} {player.Col}");
        }

        private static string MovePlayer(char[][] jag, ref Point player, char command)
        {
            SetPointInJag(jag, player, '.');
            Point newPlayerPos = null;
            switch (command)
            {
                case 'U':
                    newPlayerPos = player.ClonePoint(-1, 0);
                    break;
                case 'D':
                    newPlayerPos = player.ClonePoint(1, 0);
                    break;
                case 'L':
                    newPlayerPos = player.ClonePoint(0, -1);
                    break;
                case 'R':
                    newPlayerPos = player.ClonePoint(0, 1);
                    break;
            }

            if (!newPlayerPos.IsInsideJag(jag))
            {
                return "won";
            }
            else
            {
                player = newPlayerPos;
                if (jag[player.Row][player.Col] == 'B')
                {
                    return "dead";
                }
                else
                {
                    SetPointInJag(jag, player, 'P');
                    return "";
                }
            }
        }

        private static Point GetPlayer(char[][] jag)
        {
            for (int i = 0; i < jag.Length; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                {
                    if (jag[i][j] == 'P')
                    {
                        return new Point(i, j);
                    }
                }
            }
            return null;
        }

        static void SpreadBunnies(char[][] jag)
        {
            Point[] bunnies = GetBunnies(jag);
            foreach (var bunny in bunnies)
            {
                SpreadBynny(jag, bunny);
            }
        }

        private static void SpreadBynny(char[][] jag, Point bunny)
        {
            var newBunny = bunny.ClonePoint(1, 0);
            SetPointInJag(jag, newBunny, 'B');

            newBunny = bunny.ClonePoint(-1, 0);
            SetPointInJag(jag, newBunny, 'B');

            newBunny = bunny.ClonePoint(0, 1);
            SetPointInJag(jag, newBunny, 'B');

            newBunny = bunny.ClonePoint(0, -1);
            SetPointInJag(jag, newBunny, 'B');
        }

        private static Point[] GetBunnies(char[][] jag)
        {
            var bunnies = new List<Point>();
            for (int i = 0; i < jag.Length; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                {
                    if (jag[i][j] == 'B')
                    {
                        bunnies.Add(new Point(i, j));
                    }
                }
            }
            return bunnies.ToArray();
        }

        static void PrintJag(char[][] jag)
        {
            for (int i = 0; i < jag.Length; i++)
            {
                for (int j = 0; j < jag[i].Length; j++)
                {
                    Console.Write(jag[i][j]);
                }
                Console.WriteLine();
            }
        }

        static void SetPointInJag(char[][] jag, Point point, char newVal)
        {
            if (point.IsInsideJag(jag))
            {
                jag[point.Row][point.Col] = newVal;
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

        public bool IsInsideJag(char[][] jag)
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

        public char GetPointVal(char[][] jag)
        {
            return jag[Row][Col];
        }
    }
}
