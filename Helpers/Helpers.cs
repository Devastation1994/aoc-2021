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
        static readonly Stopwatch stopwatch = new ();
        static int count = 0;
        static readonly string[] portions = new string[] { "Example", "Part 1", "Part 2" };
        static readonly string[] inputFiles = new string[] { "test.txt", "input.txt" };

        static Helper()
        {
            stopwatch.Start();
        }

        public static List<string> GetInput()
        {
            var input = File.ReadAllLines(inputFiles[count == 0 ? 0 : 1]).ToList();
            return input;
        }

        public static void LogAnswer(string answer)
        {
            stopwatch.Stop();
            Console.WriteLine($"{portions[count]} Answer: {answer}  Duration {stopwatch.ElapsedMilliseconds} ms");
            count++;
            stopwatch.Restart();
        }

        public static void LogAnswer(int answer)
        {
            LogAnswer(answer.ToString());
        }
    }
}
