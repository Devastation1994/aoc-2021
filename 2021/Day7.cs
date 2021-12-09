using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Year2021
{
    public class Day7
    {
        static int SolveQuestion(List<string> data, int part = 0)
        {
            var crabs = data[0].Split(',');
            var horizontalPositions = data[0].Split(',').Select(int.Parse).Distinct().ToList();
            var fuelCost = new List<int>();
            var newFuelCost = new List<int>();

            for (int i = 0; i < horizontalPositions.Max(); i++)
            {
                fuelCost.Add(0);
                newFuelCost.Add(0);

                foreach (var crab in crabs.Select(int.Parse))
                {
                    var diff = Math.Abs(crab - i);

                    fuelCost[i] += diff;

                    for (int j = 1; j <= diff; j++)
                    {
                        newFuelCost[i] += j;
                    }
                }
            }

            return part == 1 ? fuelCost.Min(): newFuelCost.Min();
        }

        static void Run()
        {
            // Test data Part 1
            Helper.LogAnswer(SolveQuestion(Helper.GetTestInput(), 1));
            
            // Test Data Part 2
            Helper.LogAnswer(SolveQuestion(Helper.GetTestInput(), 2));

            // Part 1
            Helper.LogAnswer(SolveQuestion(Helper.GetInput(), 1));

            // Part 2
            Helper.LogAnswer(SolveQuestion(Helper.GetInput(), 2));
        }
    }
}
