using Helpers;
using System;
using System.Linq;

namespace Year2021
{
    public class Day3
    {
        static void Run()
        {
            var step1Input = Helper.GetInput();
            var binaryNumber = "";

            for (var i = 0; i <= step1Input[0].Length - 1; i++)
            {
                binaryNumber += step1Input.Count(input => input[i] == '0') > step1Input.Count / 2 ? '0' : '1';
            }

            Helper.LogAnswer(Convert.ToInt32(binaryNumber, 2) * Convert.ToInt32(ReverseBinary(binaryNumber), 2));

            var oxygenGenRating = Helper.GetInput();
            var co2Rating = Helper.GetInput();

            for (int i = 0; i < step1Input[0].Length - 1; i++)
            {
                if (oxygenGenRating.Count > 1) oxygenGenRating = oxygenGenRating.Where(ogr => ogr[i] == ((oxygenGenRating.Count(ogr2 => ogr2[i] == '0') > (oxygenGenRating.Count / 2)) ? '0' : '1')).ToList();
                if (co2Rating.Count > 1) co2Rating = co2Rating.Where(co2r => co2r[i] == ((co2Rating.Count(co2r1 => co2r1[i] == '0') > (co2Rating.Count / 2)) ? '1' : '0')).ToList();
            }

            Helper.LogAnswer(Convert.ToInt32(oxygenGenRating[0], 2) * Convert.ToInt32(co2Rating[0], 2));
        }

        static string ReverseBinary(string bits)
        {
            var newBinary = "";

            foreach (var bit in bits)
            {
                newBinary += bit == '0' ? "1" : "0";
            }

            return newBinary;
        }
    }
}
