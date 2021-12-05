using AdventOfCode.DTO;
using System.Linq;
using static AdventOfCode.DTO.BingoBoard.Line;

namespace AdventOfCode
{
    public class BingoHelper
    {
        public  static int GetWinningScore(IList<int> numbersToDraw, IList<BingoBoard> boards)
        {
            var winningBoard = GetBoardWithFirstMarkedLine(numbersToDraw, boards);
            var sumOfUnmarkedNumbers = CalculateSumofUnmarkedNumbers(winningBoard);
            return 0;

        }

        private static BingoBoard GetBoardWithFirstMarkedLine(IList<int> numbersToDraw, IList<BingoBoard> boards)
        {
            foreach (int number in numbersToDraw)
            {
                var numbersToMark = boards.SelectMany(x => x.Lines.SelectMany(y => y.Numbers.Where(z => z.Value == number)).ToList());

                foreach (Number numberToMark in numbersToMark)
                    numberToMark.Marked = true;

                List<BingoBoard> allMarked = new List<BingoBoard>();

                allMarked.AddRange(boards.Where(x => x.Lines.Any(y => y.Numbers.Count(z => z.Marked == true) == 5)));

                IList<BingoBoard> columnsAllMarked = new List<BingoBoard>();

                for (int i = 0; i < 4; i++)
                {
                    allMarked.AddRange(boards.Where(x => x.Lines.Any(y => y.Numbers.Select((number, index) => (number, index)).Any(z => z.index == i)) == 5)));                    
                }      

                if (allMarked.Any())
                    return allMarked.First();
            }
            return new BingoBoard();
        }

        private static int CalculateSumofUnmarkedNumbers(BingoBoard winningBoard)
        {
            var unMarkedNumbers = winningBoard.Lines.SelectMany(x => x.Numbers.Where(y => y.Marked == false));

            return 0;
        }
    }
}