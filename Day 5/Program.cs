using Helpers;
using System;
using System.Linq;

namespace Day_5
{
    public class Program
    {
        static int maxValue = 1001;
        static string[,] grid = new string[maxValue, maxValue];

        static void Main()
        {            
            var input = Helper.GetInputAsString();

            for (int i = 0; i < maxValue; i++)
            {
                for (int j = 0; j < maxValue; j++)
                {
                    grid[i, j] = ".";
                }
            }

            foreach (var set in input)
            {
                var numbers = set.Split(new string[] { "->", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var x1 = numbers[0];
                var y1 = numbers[1];
                var x2 = numbers[2];
                var y2 = numbers[3];

                //2D ARRAYS ARE Y/X

                // x1 -> x2
                // Is horizontal
                if (y1 == y2)
                {
                    // Go left
                    if (x1 > x2)
                    {
                        for (int i = x1; i >= x2; i--)
                        {
                           UpdateField(y1, i);
                        }
                    }
                    // Go right
                    else
                    {
                        for (int i = x1; i <= x2; i++)
                        {
                            UpdateField(y1, i);
                        }
                    }
                }
                // Is Vertical
                else if (x1 == x2)
                {
                    // Go up
                    if (y1 > y2)
                    {
                        for (int i = y1; i >= y2; i--)
                        {
                           UpdateField(i, x1);
                        }
                    }
                    // Go down
                    else
                    {
                        for (int i = y1; i <= y2; i++)
                        {
                            UpdateField(i, x1);
                        }
                    }
                }
                // Diagonal
                else
                {
                    // Up right
                    if (x1 < x2 && y1 > y2)
                    {
                        for (int i = 0; i <= x2 - x1; i++)
                        {
                            UpdateField(y1 - i, x1 + i);
                        }
                    }
                    // Up left
                    else if (x1 > x2 && y1 > y2)
                    {
                        for (int i = 0; i <= x1 - x2; i++)
                        {
                            UpdateField(y1 - i,x1 - i);
                        }
                    }
                    // Down right
                    else if (x1 < x2 && y1 < y2)
                    {
                        for (int i = 0; i <= y2 - y1; i++)
                        {
                            UpdateField(y1 + i, x1 + i);
                        }
                    }
                    // Down left
                    else if (x1 > x2 && y1 < y2)
                    {
                        for (int i = 0; i <= y2 - y1; i++)
                        {
                            UpdateField(y1 + i, x1 - i);
                        }
                    }
                    else
                    {
                        // should never hit this if other conditions are met
                        throw new Exception("YOU SUCK");
                    }
                }
            }

            var overlaps = 0;
            foreach (var item in grid)
            {
                if (item != "." && int.Parse(item) >= 2)
                {
                    overlaps++;
                }
            }

            if (maxValue  < 1000)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            Helper.LogAnswer(overlaps);            

            Helper.LogAnswer("");
        }

        public static void UpdateField(int j, int i )
        {
            grid[j,i] = grid[j,i] == "." ? "1" : (int.Parse(grid[j,i]) + 1).ToString();
        }
    }
}
