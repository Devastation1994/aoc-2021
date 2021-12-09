using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Helpers
{
    public static class Helper
    {
        static readonly Stopwatch stopwatch = new ();
        static int count = 0;
        static readonly string[] portions = new string[] { "Example Part 1", "Example Part 2", "Part 1", "Part 2" };

        static Helper()
        {
            stopwatch.Start();
        }

        public static List<string> GetInput()
        {
            var input = File.ReadAllLines("input.txt").ToList();
            return input;
        }

        public static List<string> GetTestInput()
        {
            var input = File.ReadAllLines("test.txt").ToList();
            return input;
        }

        public static List<string> GetInputFromApi(int day)
        {
            var client = new WebClient();
            client.Headers.Add("cookie", "session=53616c7465645f5fc557fc794c2d46bebaeb0cd04c16c63df2c0b6bcd9a030b9a40af28eed3908363e362e13a3a56191");
            return client.DownloadString($"https://adventofcode.com/2021/day/{day}/input").Split("\n").ToList();
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
