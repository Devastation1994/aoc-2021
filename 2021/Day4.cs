using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Year2021
{
    public class Day4
    {
       public static void Run()
        {
            var input = Helper.GetInput();
            var selectedNumbers = input[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var bingoSheetNumbers = new List<string>();
            input.RemoveAt(0);

            var count = 0;
            foreach (var row in input.Where(i => !string.IsNullOrWhiteSpace(i)))
            {
                foreach (var column in row.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    bingoSheetNumbers.Add(column);
                }
                count++;
            }

            var foundIndexes = new List<string>();
            var winningBoardIndex = new List<int>();
            var winningBoardCalc = new List<int>();

            for (int i = 0; i < selectedNumbers.Count; i++)
            {
                for (int j = 0; j < bingoSheetNumbers.Count; j++)
                {
                    if (selectedNumbers[i] == bingoSheetNumbers[j])
                    {
                        bingoSheetNumbers[j] = "X";
                    }

                    var winnerFound = WinnerFound(bingoSheetNumbers, winningBoardIndex);

                    if (winnerFound != null)
                    {
                        winningBoardIndex.Add(int.Parse(winnerFound.ToString()));
                        winningBoardCalc.Add(bingoSheetNumbers.GetRange(winningBoardIndex[winningBoardIndex.Count - 1], 25).Where(i => i != "X").Select(int.Parse).Sum() * int.Parse(selectedNumbers[i]));
                    }
                }
            }

            Helper.LogAnswer(winningBoardCalc[0]);

            input = Helper.GetInput();

            Helper.LogAnswer(winningBoardCalc[winningBoardCalc.Count - 1]);
        }

        private static int? WinnerFound(List<string> bingoSheetNumbers, List<int> winningBoardIndex)
        {
            for (int i = 0; i < bingoSheetNumbers.Count; i += 25)
            {
                if (
                    // Horizontal
                    ((bingoSheetNumbers[i] == "X" && bingoSheetNumbers[i + 1] == "X" && bingoSheetNumbers[i + 2] == "X" && bingoSheetNumbers[i + 3] == "X" && bingoSheetNumbers[i + 4] == "X") ||
                    (bingoSheetNumbers[i + 5] == "X" && bingoSheetNumbers[i + 6] == "X" && bingoSheetNumbers[i + 7] == "X" && bingoSheetNumbers[i + 8] == "X" && bingoSheetNumbers[i + 9] == "X") ||
                    (bingoSheetNumbers[i + 10] == "X" && bingoSheetNumbers[i + 11] == "X" && bingoSheetNumbers[i + 12] == "X" && bingoSheetNumbers[i + 13] == "X" && bingoSheetNumbers[i + 14] == "X") ||
                    (bingoSheetNumbers[i + 15] == "X" && bingoSheetNumbers[i + 16] == "X" && bingoSheetNumbers[i + 17] == "X" && bingoSheetNumbers[i + 18] == "X" && bingoSheetNumbers[i + 19] == "X") ||
                    (bingoSheetNumbers[i + 20] == "X" && bingoSheetNumbers[i + 21] == "X" && bingoSheetNumbers[i + 22] == "X" && bingoSheetNumbers[i + 23] == "X" && bingoSheetNumbers[i + 24] == "X") ||
                    //Vertical
                    (bingoSheetNumbers[i] == "X" && bingoSheetNumbers[i + 5] == "X" && bingoSheetNumbers[i + 10] == "X" && bingoSheetNumbers[i + 15] == "X" && bingoSheetNumbers[i + 20] == "X") ||
                    (bingoSheetNumbers[i + 1] == "X" && bingoSheetNumbers[i + 6] == "X" && bingoSheetNumbers[i + 11] == "X" && bingoSheetNumbers[i + 16] == "X" && bingoSheetNumbers[i + 21] == "X") ||
                    (bingoSheetNumbers[i + 2] == "X" && bingoSheetNumbers[i + 7] == "X" && bingoSheetNumbers[i + 12] == "X" && bingoSheetNumbers[i + 17] == "X" && bingoSheetNumbers[i + 22] == "X") ||
                    (bingoSheetNumbers[i + 3] == "X" && bingoSheetNumbers[i + 8] == "X" && bingoSheetNumbers[i + 13] == "X" && bingoSheetNumbers[i + 18] == "X" && bingoSheetNumbers[i + 23] == "X") ||
                    (bingoSheetNumbers[i + 4] == "X" && bingoSheetNumbers[i + 9] == "X" && bingoSheetNumbers[i + 14] == "X" && bingoSheetNumbers[i + 19] == "X" && bingoSheetNumbers[i + 24] == "X"))
                    && !winningBoardIndex.Contains(i))
                {
                    return i;
                }
            }

            return null;
        }
    }
}
