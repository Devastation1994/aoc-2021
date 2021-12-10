using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021
{
    public class Day10
    {
        static void SolveQuestion(List<string> data)
        {
            var openingCharacters = new List<string> { "(", "[", "{", "<", };
            var closingCharacters = new List<string> { ")", "]", "}", ">" };
            var part1Value = new int[] { 3, 57, 1197, 25137 };
            var illegalCharacters = new List<string>();
            var part2 = new List<string>();

            // Part 1
            var endings = new List<string>();
            var incompleteLines = new List<string>();

            foreach (var line in data)
            {
                endings.Add("");
                var badLine = false;

                foreach (var column in line)
                {
                    var index = closingCharacters.IndexOf(column.ToString()) != -1 ?
                        closingCharacters.IndexOf(column.ToString()) : openingCharacters.IndexOf(column.ToString());

                    if (openingCharacters.Contains(column.ToString()))
                    {
                        endings[^1] += (closingCharacters[index]);
                        continue;
                    }

                    if (column.ToString() == endings[^1][^1].ToString())
                    {
                        endings[^1] = endings[^1].Remove(endings[^1].Count() - 1);
                    }
                    else
                    {
                        illegalCharacters.Add(column.ToString());
                        badLine = true;
                        break;
                    }
                }

                if (!badLine)
                {
                    incompleteLines.Add(endings[^1]);
                }
            }

            var part1 = 0;

            foreach (var character in illegalCharacters)
            {
                part1 += part1Value[closingCharacters.IndexOf(character.ToString())];
            }

            Helper.LogAnswer(part1);

            // Part 2
            var output2 = new List<long>();

            for (int i = 0; i < incompleteLines.Count; i++)
            {
                output2.Add(0);

                for (int j = incompleteLines[i].Count() - 1; j >= 0; j--)
                {
                    output2[^1] *= 5;
                    output2[^1] += closingCharacters.IndexOf(incompleteLines[i][j].ToString()) + 1;
                }
            }

            Helper.LogAnswer(output2.OrderBy(i => i).ToList()[output2.Count / 2]);
        }

        public static void Run()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            SolveQuestion(Helper.GetInput());
        }
    }
}
