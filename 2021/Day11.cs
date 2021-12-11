using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public class Day11
    {
        static int[,] grid;
        static int maxX;
        static int maxY;
        static List<string> flashList;
        static int flashCount;

        static void SolveQuestion(List<string> data)
        {
            grid = new int[data.Count, data[0].Length];
            flashCount = 0;
            var part1 = 0;
            var part2 = 0;

            // convert list to 2d array
            // row
            for (int i = 0; i < data.Count; i++)
            {
                // column
                for (int j = 0; j < data[i].Length; j++)
                {
                    grid[i, j] = int.Parse(data[i][j].ToString());
                }
            }

            maxX = grid.GetLength(1) - 1;
            maxY = grid.GetLength(0) - 1;

            var count = 1;
            while (part2 == 0)
            {
                flashList = new List<string>();
                var queuedOctopus = new List<Tuple<int, int>>();

                // Increase every octopus by 1
                for (int x = 0; x <= maxX; x++)
                {
                    for (int y = 0; y <= maxY; y++)
                    {
                        grid[y, x]++;
                        if (grid[y, x] > 9)
                        {
                            queuedOctopus.Add(new Tuple<int, int>(y, x));
                        }
                    }
                }
                
                foreach (var octupus in queuedOctopus)
                {
                    Recursion((octupus.Item1, octupus.Item2));
                }

                if (flashList.Count() == (maxX + 1) * (maxY + 1))
                {
                    part2 = count;
                }

                count++;
            }

            Helper.LogAnswer(part1);
            Helper.LogAnswer(part2);
        }

        static void Recursion((int y, int x) cords)
        {
            var value = $"{cords.y},{cords.x}";

            if (cords.y < 0 || cords.x < 0 || cords.y > maxY || cords.x > maxX || flashList.Contains(value))
            {
                return;
            }

            grid[cords.y, cords.x]++;

            if (grid[cords.y, cords.x] > 9)
            {
                flashCount++;
                flashList.Add(value);
                grid[cords.y, cords.x] = 0;

                Recursion((cords.y - 1, cords.x));
                Recursion((cords.y - 1, cords.x + 1));
                Recursion((cords.y, cords.x + 1));
                Recursion((cords.y + 1, cords.x + 1));
                Recursion((cords.y + 1, cords.x));
                Recursion((cords.y + 1, cords.x - 1));
                Recursion((cords.y, cords.x - 1));
                Recursion((cords.y - 1, cords.x - 1));
            }
        }

        //17xx
        public static void Run()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            SolveQuestion(Helper.GetInput());
        }
    }
}
