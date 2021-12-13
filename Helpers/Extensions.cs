using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Extensions
    {
        public static int[,] ConvertTo2dIntArray(this List<string> data)
        {
            var grid = new int[data.Count, data[0].Length];
            // row
            for (int i = 0; i < data.Count; i++)
            {
                // column
                for (int j = 0; j < data[i].Length; j++)
                {
                    grid[i, j] = int.Parse(data[i][j].ToString());
                }
            }

            return grid;
        }
    }
}
