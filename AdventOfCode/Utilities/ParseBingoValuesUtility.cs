using AdventOfCode.DTO;
using static AdventOfCode.DTO.BingoBoard;
using static AdventOfCode.DTO.BingoBoard.Line;

namespace AdventOfCode
{
    public static class ParseBingoValuesUtility
    {
        public static IList<int> ParsedNumbersToDraw(string fileLine) => fileLine.Split(',').Select(int.Parse).ToList();

        public static IList<BingoBoard> ParsedBoards(IList<string> fileLines)
        {
            IList<BingoBoard> bingoBoards = new List<BingoBoard>();

            BingoBoard board = new();

            for (int i = 2; i < fileLines.Count(); i++)
            {
                if (fileLines[i] == "")
                {
                    bingoBoards.Add(board);
                    board.Lines = new List<Line>();
                    continue;
                }

                var parsedNumbers = fileLines[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                Line parsedLine = new Line();

                foreach (var number in parsedNumbers)
                    parsedLine.Numbers.Add(new Number()   {
                        Value = number,
                        Marked = false
                });               
                                  
                board.Lines.Add(parsedLine);                           
            }

            bingoBoards.Add(board);
            return bingoBoards;
        }
    }
}