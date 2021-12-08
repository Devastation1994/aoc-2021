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
            var numberCombosPart2 = new string[10] { "cagedb", "ab,eg", "gcdfa,defbg", "fbcad,defgc", "eafb,eafg", "cdfbe,dafgc", "cdfgeb,dafgbc", "dab,deg", "acedgfb", "cefabd,agcdef" };

            

            var outputValue = new List<string>();
            var uniqueLengths = new int[4] { 2, 4, 3, 7 };
            var part1 = 0;

            foreach (var row in data)
            {
                outputValue.Add("");

                var splti = row.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var digits in splti)
                {
                    var foundDigit = false;
                    if (uniqueLengths.Contains(digits.Length))
                    {
                        part1++;
                    }

                    if (digits.Length == 2)
                    {
                        outputValue[^1] += "1";
                        continue;
                    }
                    else if (digits.Length == 3)
                    {
                        outputValue[^1] += "7";
                        continue;
                    }
                    else if (digits.Length == 4)
                    {
                        outputValue[^1] += "4";
                        continue;
                    }
                    else if (digits.Length == 7)
                    {
                        outputValue[^1] += "8";
                        continue;
                    }

                    
                    for (int i = 0; i < 10; i++)
                    {
                        if (foundDigit)
                        {
                            break;
                        }

                        foreach (var test in numberCombosPart2[i].Split(',',StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (test == digits)
                            {
                                outputValue[^1] += i.ToString();
                                foundDigit = true;
                                break;
                            }
                        }
                    }
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
