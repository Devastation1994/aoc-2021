using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_8
{
    public class Program
    {
        static void SolveQuestion(List<string> data)
        {
            var numberCombos = new string[10] { "abcefg", "cf", "acdeg", "acdfg", "bcdf", "abdfg", "abdefg", "acf", "abcdefg", "abcdfg" };
            var numberCombosPart2 = new string[10] { "012456", "25", "02346", "02356", "1235", "01356", "013456", "025", "0123456", "012356" };
            var outputValue = new List<string>();
            var uniqueLengths = new int[4] { 2, 4, 3, 7 };
            var part1 = 0;
            var letters = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            

            //1-8 2-6 3-8 4-7 5-4 6-9 7-7
            
            foreach (var row in data)
            {
                outputValue.Add("");
                var segmentOrder = new List<string>(new string[7]);
                var letterCount = new List<int>();
                var outputs = row.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
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

                foreach (var character in segments.Where(i => i.Length == 2).First())
                {
                    if (segmentOrder[5].ToString() != character.ToString())
                    {
                        segmentOrder[2] = character.ToString();
                        break;
                    }
                }

                foreach (var character in segments.Where(i => i.Length == 3).First())
                {
                    if (!segmentOrder.Contains(character.ToString()))
                    {
                        segmentOrder[0] = character.ToString();
                        break;
                    }
                }

                foreach (var character in segments.Where(i => i.Length == 4).First())
                {
                    if(!segmentOrder.Contains(character.ToString()))
                    {
                        segmentOrder[3] = character.ToString();
                    }
                }

                foreach (var letter in letters)
                {
                    if (!segmentOrder.Contains(letter.ToString()))
                    {
                        segmentOrder[6] = letter;
                    }
                }

                foreach (var output in outputs)
                {
                    if (uniqueLengths.Contains(output.Length))
                    {
                        part1++;
                    }

                    var test = "";
                    foreach (var character in output)
                    {
                        test += segmentOrder.IndexOf(character.ToString());
                    }

                    var test1 = test.ToCharArray();

                    Array.Sort(test1);

                    outputValue[^1] += numberCombosPart2.ToList().IndexOf(new string(test1));
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

        static void Main()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            SolveQuestion(Helper.GetInput());
        }
    }
}
