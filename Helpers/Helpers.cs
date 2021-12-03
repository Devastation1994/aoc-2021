using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Helpers
{
    public static class Helper
    {
        static readonly Stopwatch stopwatch = new();

        public static List<string> GetInputAsString()
        {
            return File.ReadAllLines("input.txt").ToList();
        }

        public static List<int> GetInputAsInt()
        {
            return GetInputAsString().Select(int.Parse).ToList();
        }

        public static void StartAnswer()
        {
            stopwatch.Restart();
        }

        public static void EndAnswer(string answer)
        {
            stopwatch.Stop();
            Console.WriteLine($"Answer: {answer}  Duration {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void EndAnswer(int answer)
        {
            EndAnswer(answer.ToString());
        }
    }
}
