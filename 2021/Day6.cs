using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Year2021
{
    public class Day6
    {
        static string SolveQuestion(List<string> data, int maxDays)
        {
            var days = 1;
            var lanturnFish = new long[9];

            foreach (var item in data[0].Split(','))
            {
                lanturnFish[long.Parse(item)]++;
            }

            while (days <= maxDays)
            {
                var temp = new long[9];
                var zeroFish = lanturnFish[0];

                for (int i = lanturnFish.Length - 1; i > 0; i--)
                {
                    temp[i - 1] = lanturnFish[i];
                }

                temp[6] += zeroFish;
                temp[8] += zeroFish;

                days++;
                lanturnFish = temp;
            }

            return lanturnFish.Sum().ToString();
        }

        static void Run()
        {
            // Test data

            Helper.LogAnswer(SolveQuestion(Helper.GetInput(), 18));
            // Part 1

            Helper.LogAnswer(SolveQuestion(Helper.GetInput(), 80));

            // Part 2

            Helper.LogAnswer(SolveQuestion(Helper.GetInput(), 256));
        }
    }
}
