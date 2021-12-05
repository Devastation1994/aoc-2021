using Helpers;
using System;
using System.Linq;

namespace Day_5
{
    public class Program
    {
        static void Main()
        {
            var maxValue = 1000;
            var input = Helper.GetInputAsString();
            var grid = new string[maxValue, maxValue];

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
                            grid[y1, i] = UpdateField(grid[y1, i]);
                        }
                    }
                    // Go right
                    else
                    {
                        for (int i = x1; i <= x2; i++)
                        {
                            grid[y1, i] = UpdateField(grid[y1, i]);
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
                            grid[i, x1] = UpdateField(grid[i, x1]);
                        }
                    }
                    // Go down
                    else
                    {
                        for (int i = y1; i <= y2; i++)
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

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }

            //input = Helper.GetInputAsString();

            Helper.LogAnswer("");
        }

        public static string UpdateField(string value)
        {

            return value == "." ? "1" : (int.Parse(value) + 1).ToString();
        }
    }
}
