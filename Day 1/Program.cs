using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace AoC2021
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Helper.GetInputAsInt();
            var count = 0;

            for(var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[i-1])
                {
                    count++;                    
                }
            }

            Helper.LogAnswer(count);
            
            count = 0;
            var measurement = numbers.GetRange(0, 3).Sum();

            for (var i = 1; i < numbers.Count - 2; i++)
            {
                var calc = numbers.GetRange(i, 3).Sum();

                if (calc > measurement)
                {
                    count++;
                }

                measurement = calc;
            }

            Helper.LogAnswer(count);
        }
    }
}
