using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public class Day13
    {
        static void SolveQuestion(List<string> data)
        {
            string[,] grid;
            string[,] newGrid;
            var foldAlongList = new List<string>();
            var foldInstructions = new List<int>();
            int maxX = 0;
            int maxY = 0;

            foreach (var row in data)
            {
                if (row.Contains(","))
                {
                    var dots = row.Split(',')?.Select(int.Parse).ToList();

                    if (maxX < dots[0])
                    {
                        maxX = dots[0];
                    }
                    if (maxY < dots[1])
                    {
                        maxY = dots[1];
                    }
                }
                else if (row.Contains("="))
                {
                    foldAlongList.Add(row.Split(' ')[2]);
                }
            }

            grid = Helper.Initialize2dArray(maxY + 1, maxX + 1, ".");

            for (int i = 0; i < (data.Count - (foldAlongList.Count + 1)); i++)
            {
                var dots = data[i].Split(',')?.Select(int.Parse).ToList();

                grid[dots[1], dots[0]] = "#";
            }

            foreach (var fold in foldAlongList)
            {
                grid = FoldGrid(grid, fold);
                Helper.WriteLine($"Post {fold} fold");
                grid.Print2dArray();
                break;
            }

            var count = 0;
            foreach (var item in grid)
            {
                if (item == "#")
                {
                    count++;
                }
            }

            Helper.LogAnswer(count);
        }

        public static string[,] FoldGrid(string[,] grid, string fold)
        {
            var split = fold.Split('=');
            string[,] newGrid;
            var maxX = grid.GetLength(1) - 1;
            var maxY = grid.GetLength(0) - 1;

            switch (split[0])
            {
                case "y":
                    newGrid = Helper.Initialize2dArray((maxY + 1) / 2, maxX, ".");
                    for (int x = 0; x <= maxX; x++)
                    {
                        for (int y = 0; y <= maxY; y++)
                        {
                            if (y == maxY && x == 0)
                            {

                            }
                            if (y >= maxY / 2)
                            {
                                newGrid[maxY - y, x] = grid[y, x];
                            }
                            else
                            {
                                newGrid[y, x] = grid[y, x];
                            }
                        }
                    }
                    return newGrid;
                case "x":
                    newGrid = Helper.Initialize2dArray(maxY, (maxX + 1) / 2, ".");
                    for (int x = 0; x < maxX; x++)
                    {
                        for (int y = 0; y < maxY; y++)
                        {
                            if (x > maxX + 1 / 2)
                            {
                                newGrid[maxX - y, x] = grid[y, x];
                            }
                            else
                            {
                                newGrid[y, x] = grid[y, x];
                            }
                        }
                    }
                    return newGrid;
            }
            throw new Exception("oh");
        }

        public static void Run()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            //SolveQuestion(Helper.GetInput());
        }
    }
}
