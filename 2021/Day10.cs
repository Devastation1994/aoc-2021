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
            var illegalCharacters = new List<string>();

            foreach (var line in data)
            {
                if (line == "{([(<{}[<>[]}>{[]{[(<()>")
                {

                }

                var openings = new List<string>();
                var endings = new List<string>();

                foreach (var column in line)
                {
                    if (openingCharacters.Contains(column.ToString()))
                    {
                        openings.Add(column.ToString());
                        continue;
                    }
                    else
                    {
                        endings.Add(column.ToString());
                    }

                    for (int i = 0; i < closingCharacters.Count; i++)
                    {
                        var test = openings.Count(oc => oc == openingCharacters[i]);
                        var test1 = endings.Count(cc => cc == closingCharacters[i]);

                        if (openings.Count(oc => oc == openingCharacters[i]) < endings.Count(cc => cc == closingCharacters[i]))
                        {
                            illegalCharacters.Add(column.ToString());
                            break;
                        }
                    }
                }
            }

            var output = 0;

            foreach (var character in illegalCharacters)
            {
                switch (character)
                {
                    case ")":
                        output += 3;
                        break;
                    case "]":
                        output += 57;
                        break;
                    case "}":
                        output += 1197;
                        break;
                    case ">":
                        output += 25137;
                        break;

                }
            }

            Helper.LogAnswer(output);
        }

        public static void Run()
        {
            // Test data
            SolveQuestion(Helper.GetTestInput());

            // Part 2
            //SolveQuestion(Helper.GetInput());
        }
    }
}
