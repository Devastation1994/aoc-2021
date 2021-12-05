﻿using System;
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

        public static List<string> GetDataAsString()
        {
            var input = File.ReadAllLines("input.txt").ToList();
            stopwatch.Restart();
            return input;
        }

        public static List<int> GetDataAsInt()
        {
            return GetDataAsString().Select(int.Parse).ToList();
        }

        public static List<string> GetTestDataAsString()
        {
            var input = File.ReadAllLines("input.txt").ToList();
            stopwatch.Restart();
            return input;
        }

        public static List<int> GetTestDataAsInt()
        {
            return GetDataAsString().Select(int.Parse).ToList();
        }

        public static void LogAnswer(string answer)
        {
            stopwatch.Stop();
            Console.WriteLine($"Answer: {answer}  Duration {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Restart();
        }

        public static void LogAnswer(int answer)
        {
            LogAnswer(answer.ToString());
        }
    }
}
