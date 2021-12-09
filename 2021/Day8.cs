using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Year2021
{
    public class Day8
    {
        static void SolveQuestion(List<string> data)
        {
            var numberCombos = new string[10] { "abcefg", "cf", "acdeg", "acdfg", "bcdf", "abdfg", "abdefg", "acf", "abcdefg", "abcdfg" };
            var numberCombosPart2 = new string[10] { "012456", "25", "02346", "02356", "1235", "01356", "013456", "025", "0123456", "012356" };
            var outputValue = new List<string>();
            var uniqueLengths = new int[4] { 2, 4, 3, 7 };
            var part1 = 0;
            var letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            
            foreach (var row in data)
            {
                outputValue.Add("");
                var segmentOrder = new List<char>(new char[7]);
                var letterCount = new List<int>();
                var segments = row.Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < letters.Length; i++)
                {
                    letterCount.Add(0);

                    foreach (var segment in segments)
                    {
                        if (segment.Contains(letters[i]))
                        {
                            letterCount[i]++;
                        }
                    }
                }
                
                segmentOrder[1] = letters[letterCount.IndexOf(6)];
                segmentOrder[4] = letters[letterCount.IndexOf(4)];
                segmentOrder[5] = letters[letterCount.IndexOf(9)];
                segmentOrder[2] = segments.Where(i => i.Length == 2).First().ToCharArray().Where(i => i != segmentOrder[5]).First();
                segmentOrder[0] = segments.Where(i => i.Length == 3).First().ToCharArray().Where(i => !segmentOrder.Contains(i)).First();
                segmentOrder[3] = segments.Where(i => i.Length == 4).First().ToCharArray().Where(i => !segmentOrder.Contains(i)).First();
                segmentOrder[6] = letters.Where(i => !segmentOrder.Contains(i)).First();

                foreach (var output in row.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    var test = "";
                    foreach (var character in output)
                    {
                        test += segmentOrder.IndexOf(character);
                    }

                    var test1 = test.ToCharArray();

                    Array.Sort(test1);

                    outputValue[^1] += numberCombosPart2.ToList().IndexOf(new string(test1));

                    part1 += uniqueLengths.Contains(output.Length) ? 1 : 0;
                }
            }

            //Part 1
            Helper.LogAnswer(part1);

            // Part 2
            Helper.LogAnswer(outputValue.Select(int.Parse).Sum());
        }

        public static string SortString(string value)
        {
            var chars = value.ToArray();
            Array.Sort(chars);
            return new string(chars);
        }

        static void Run()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            SolveQuestion(Helper.GetInput());
        }
    }
}
