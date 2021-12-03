using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_3
{
    class Day3
    {
        static void Main(string[] args)
        {
            var step1Input = Helper.GetInputAsString(3);
            var binaryNumber1 = "";
            var binaryNumber2 = "";

            for (int i = 0; i <= 11; i++)
            {
                var zeroBit = step1Input.Where(input => input[i] == '0').Count();
                var oneBit = step1Input.Where(input => input[i] == '1').Count();

                binaryNumber1 += zeroBit > oneBit ? '0' : '1';
                binaryNumber2 += zeroBit < oneBit ? '0' : '1';
            }

            Helper.LogAnswer(3, 1, Convert.ToInt32(binaryNumber1, 2) * Convert.ToInt32(binaryNumber2, 2));

            var oxygenGenRating = Helper.GetInputAsString(3);
            var co2Rating = Helper.GetInputAsString(3);

            for (int i = 0; i <= 12; i++)
            {
                var zeroBit = 0;
                var oneBit = 0;

                if (oxygenGenRating.Count > 1)
                {
                    zeroBit = oxygenGenRating.Count(input => input[i] == '0');
                    oneBit = oxygenGenRating.Count(input => input[i] == '1');

                    if (oneBit >= zeroBit)
                    {
                        oxygenGenRating.RemoveAll(ogr => ogr[i] == '0');
                    }
                    else
                    {
                        oxygenGenRating.RemoveAll(ogr => ogr[i] == '1');
                    }
                }

                if (co2Rating.Count > 1)
                {
                    zeroBit = co2Rating.Count(input => input[i] == '0');
                    oneBit = co2Rating.Count(input => input[i] == '1');

                    if (oneBit >= zeroBit)
                    {
                        co2Rating.RemoveAll(ogr => ogr[i] == '1');
                    }
                    else
                    {
                        co2Rating.RemoveAll(ogr => ogr[i] == '0');
                    }
                }
            }

            Helper.LogAnswer(3, 2, Convert.ToInt32(oxygenGenRating[0], 2) * Convert.ToInt32(co2Rating[0], 2));
        }
    }
}
