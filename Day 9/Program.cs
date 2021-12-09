using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_9
{
    public class Program
    {
        static List<int> basins = new List<int>();
        static string allBasins = "";

        static void SolveQuestion(List<string> data)
        {
            var heatmap = new int[data.Count,data[0].Length];

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

                Recursion(index, heatmap, 0);
            }

            basins.Sort();

            //Part 1
            Helper.LogAnswer(lowPoints);

            basins.Sort();
            basins.Reverse();

            // Part 2
            Helper.LogAnswer(basins[0] * basins[1] * basins[2]);
        }

        public static void Recursion(List<int> index, int[,] heatmap, int count)
        {
            var x = heatmap.GetLength(1) - 1;
            var y = heatmap.GetLength(0) - 1;

            // left
            while ((index[1] - count) >= 0)
            {
                if (heatmap[index[0], index[1] - count] == 9)
                {
                    break;
                }

                var value = $"{index[0]},{index[1] - count}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;
                    
                    Recursion(new List<int> { index[0], index[1] - count }, heatmap, count);
                }
                count++;
            }
            count = 0;
            // right
            while ((index[1] + count) <= x)
            {
                if (heatmap[index[0], index[1] + count] == 9)
                {
                    break;
                }

                var value = $"{index[0]},{index[1] + count}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;

                    Recursion(new List<int> { index[0], index[1] + count }, heatmap, count);
                }
                count++;
            }
            count = 0;
            // up
            while ((index[0] - count >= 0))
            {
                if (heatmap[index[0] - count, index[1]] == 9)
                {
                    break;
                }

                var value = $"{index[0] - count},{index[1]}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;

                    Recursion(new List<int> { index[0] - count, index[1] }, heatmap, count);
                }
                count++;
            }
            count = 0;
            // down
            while ((index[0] + count <= y))
            {
                if (heatmap[index[0] + count, index[1]] == 9)
                {
                    break;
                }

                var value = $"{index[0] + count},{index[1]}:";

                if (!allBasins.Contains(value))
                {
                    basins[^1]++;
                    allBasins += value;
                    
                    Recursion(new List<int> { index[0] + count, index[1] }, heatmap, count);
                }
                count++;
            }
        }

        static void Main()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            SolveQuestion(Helper.GetInput());
        }
    }
}
