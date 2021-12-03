using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Helpers
{
    public static class Helper
    {
        public static List<string> GetInputAsString()
        {
            return File.ReadAllText($"input.txt").Replace("\r","").Split('\n').ToList();
        }

        public static List<int> GetInputAsInt()
        {
            return GetInputAsString().Select(int.Parse).ToList();
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
