using Helpers;
using System;

namespace Day_2
{
    public class Program
    {
        static void Main()
        {
            var inputs = Helper.GetInputAsString();
            Helper.StartAnswer();
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

            Helper.EndAnswer(horizontalPosition * depth);
            Helper.StartAnswer();

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

            Helper.EndAnswer(horizontalPosition * depth);
        }
    }
}
