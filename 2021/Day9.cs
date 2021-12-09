using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Year2021
{
    public class Day9
    {
        static List<int> basins = new List<int>();
        static string allBasins = "";
        static int[,] heatmap;

        public static void Run()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            SolveQuestion(Helper.GetInput());
        }

        static void SolveQuestion(List<string> data)
        {
            heatmap = new int[data.Count,data[0].Length];
            basins = new List<int>();
            allBasins = "";

            // row
            for (int i = 0; i < data.Count; i++)
            {
                // column
                for (int j = 0; j < data[i].Length; j++)
                {
                    heatmap[i, j] = int.Parse(data[i][j].ToString());
                }
            }

            var lowPoints = 0;
            var x = heatmap.GetLength(1) - 1;
            var y = heatmap.GetLength(0) - 1;
            var lowPointList = new List<string>();

            // row
            for (int i = 0; i <= x; i++)
            {
                // column
                for (int j = 0; j <= y; j++)
                {
                    var value = heatmap[j, i];

                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            if (value < heatmap[j,i+1] && value < heatmap[j+1,i])
                            {
                                lowPoints += value + 1;
                                lowPointList.Add($"{j},{i}");
                            }
                        }
                        else if (i == x)
                        {
                            if (value < heatmap[j,i-1] && value < heatmap[j+1,i])
                            {
                                lowPoints += value + 1;
                                lowPointList.Add($"{j},{i}");
                            }
                        }
                        else
                        {
                            if (value < heatmap[j, i + 1] && value < heatmap[j + 1, i] && value < heatmap[j, i - 1])
                            {
                                lowPoints += value + 1;
                                lowPointList.Add($"{j},{i}");
                            }
                        }
                    }
                    else if (j == y)
                    {
                        if (i == 0)
                        {
                            if (value < heatmap[j, i + 1] && value < heatmap[j - 1, i])
                            {
                                lowPoints += value + 1;
                                lowPointList.Add($"{j},{i}");
                            }
                        }
                        else if (i == x)
                        {
                            if (value < heatmap[j, i - 1] && value < heatmap[j - 1, i])
                            {
                                lowPoints += value + 1;
                                lowPointList.Add($"{j},{i}");
                            }
                        }
                        else
                        {
                            if (value < heatmap[j, i + 1] && value < heatmap[j - 1, i] && value < heatmap[j, i - 1])
                            {
                                lowPoints += value + 1;
                                lowPointList.Add($"{j},{i}");
                            }
                        }
                    }
                    else if (i == 0)
                    {
                        if (value < heatmap[j, i+1] && value < heatmap[j+1, i] && value < heatmap[j - 1, i])
                        {
                            lowPoints += value + 1;
                            lowPointList.Add($"{j},{i}");
                        }
                    }
                    else if (i == x)
                    {
                        if (value < heatmap[j, i - 1] && value < heatmap[j + 1, i] && value < heatmap[j - 1, i])
                        {
                            lowPoints += value + 1;
                            lowPointList.Add($"{j},{i}");
                        }
                    }
                    else
                    {
                        if (value < heatmap[j - 1, i] && value < heatmap[j + 1, i] && value < heatmap[j, i - 1] && value < heatmap[j, i + 1])
                        {
                            lowPoints += value + 1;
                            lowPointList.Add($"{j},{i}");
                        }
                    }
                }
            }

            for (int i = 0; i < lowPointList.Count; i++)
            {
                basins.Add(0);
                var index = lowPointList[i].Split(',').Select(int.Parse).ToList();

                Recursion((index[0],index[1]));
            }

            //Part 1
            Helper.LogAnswer(lowPoints);

            basins.Sort();
            basins.Reverse();

            // Part 2
            Helper.LogAnswer(basins[0] * basins[1] * basins[2]);
        }

        public static void Recursion((int y, int x) cords)
        {
            var maxX = heatmap.GetLength(1);
            var maxY = heatmap.GetLength(0);
            var count = 0;

            // left
            while ((cords.x - count) >= 0)
            {
                if (heatmap[cords.y, cords.x - count] == 9)
                {
                    break;
                }

                var value = $"{cords.y},{cords.x - count}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;
                    Recursion((cords.y, cords.x - count));
                }
                count++;
            }
            count = 0;
            // right
            while ((cords.x + count) < maxX)
            {
                if (heatmap[cords.y, cords.x + count] == 9)
                {
                    break;
                }

                var value = $"{cords.y},{cords.x + count}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;
                    Recursion((cords.y, cords.x + count));
                }
                count++;
            }
            count = 0;
            // up
            while ((cords.y - count >= 0))
            {
                if (heatmap[cords.y - count, cords.x] == 9)
                {
                    break;
                }

                var value = $"{cords.y - count},{cords.x}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;
                    Recursion((cords.y - count, cords.x));
                }
                count++;
            }
            count = 0;
            // down
            while ((cords.y + count < maxY))
            {
                if (heatmap[cords.y + count, cords.x] == 9)
                {
                    break;
                }

                var value = $"{cords.y + count},{cords.x}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;
                    Recursion((cords.y + count, cords.x));
                }
                count++;
            }
        }

        
    }
}
