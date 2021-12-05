using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_5
{
    public class Program
    {
        static void Main()
        {
            var input = Helper.GetInputAsString();
            var grid = new string[1000, 1000];

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
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

                // x1,y1 done
                grid[y1, x1] = UpdateField(grid[y1, x1]);

                // x1 -> x2
                // Is horizontal
                if (y1 == y2)
                {
                    // Go left
                    if (x1 > x2)
                    {
                        for (int i = x1 - 1; i >= x2; i--)
                        {
                            grid[y1, i] = UpdateField(grid[y1, i]);
                        }
                    }
                    // Go right
                    else
                    {
                        for (int i = x1 + 1; i <= x2; i++)
                        {
                            grid[y1, i] = UpdateField(grid[y1, i]);
                        }
                    }
                }
                // Is Vertical
                else if (x1 == x2)
                {
                    // Go down
                    if (y1 > y2)
                    {
                        for (int i = y2 - 1; i >= y1; i--)
                        {
                            grid[i, x1] = UpdateField(grid[i, x1]);
                        }
                    }
                    // Go up
                    else
                    {
                        for (int i = y1 + 1; i <= y2; i++)
                        {
                            grid[i, x1] = UpdateField(grid[i, x1]);
                        }
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

            Helper.LogAnswer(overlaps);

            //input = Helper.GetInputAsString();

            Helper.LogAnswer("");
        }

        public static string UpdateField(string value)
        {
            return value == "." ? "1" : (int.Parse(value) + 1).ToString();
        }
    }
}
