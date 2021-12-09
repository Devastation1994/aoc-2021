using Helpers;
using System;

namespace Year2021
{
    public class Day2
    {
        static void Run()
        {
            var inputs = Helper.GetInput();
            var horizontalPosition = 0;
            var depth = 0;

            foreach (string input in inputs)
            {
                var direction = input.Split(' ')[0];
                var number = int.Parse(input.Split(' ')[1]);

                switch (direction)
                {
                    case "forward":
                        horizontalPosition += number;
                        break;
                    case "down":
                        depth += number;
                        break;
                    case "up":
                        depth -= number;
                        break;
                }
            }

            Helper.LogAnswer(horizontalPosition * depth);

            var aim = 0;
            horizontalPosition = 0;
            depth = 0;

            foreach (string input in inputs)
            {
                var direction = input.Split(' ')[0];
                var number = int.Parse(input.Split(' ')[1]);

                switch (direction)
                {
                    case "forward":
                        horizontalPosition += number;
                        depth += aim * number;
                        break;
                    case "down":
                        aim += number;
                        break;
                    case "up":
                        aim -= number;
                        break;
                }
            }

            Helper.LogAnswer(horizontalPosition * depth);
        }
    }
}
