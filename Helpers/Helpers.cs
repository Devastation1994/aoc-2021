using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Helpers
{
    public static class Helper
    {
        public static List<string> GetInputAsString(int day)
        {
            return File.ReadAllText($"day{day}.txt").Split('\n').ToList();
        }

        public static List<int> GetInputAsInt(int day)
        {
            return GetInputAsString(day).Select(int.Parse).ToList();
        }

        public static void LogAnswer(int day, int part, string answer)
        {
            Console.WriteLine($"AoC 2021 Day {day} Part {part}: {answer}");
        }

        public static void LogAnswer(int day, int part, int answer)
        {
            Console.WriteLine($"AoC 2021 Day {day} Part {part}: {answer}");
        }
    }
}
