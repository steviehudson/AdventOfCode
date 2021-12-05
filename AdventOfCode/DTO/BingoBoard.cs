namespace AdventOfCode.DTO
{
    public class BingoBoard
    {
        public IList<Line> Lines { get; set; } = new List<Line>();

        public class Line
        {
            public IList<Number> Numbers { get; set; } = new List<Number>();

            public class Number
            {
                public int Value { get; set; }
                public bool Marked { get; set; }
            }
        }
    }
}
