namespace AdventOfCode.Utilities
{
    public static class ParseUnitsUtility
    {
        public static int ParseUnit(string line)
        {
            if (int.TryParse(line, out var unit))
                return unit;
            throw new Exception("Error parsing unit");
        }

        public static int ParseContainsUnit(string line)
        {
            var unitString = line.Substring(line.IndexOf(' '));
            if (int.TryParse(unitString, out var unit))
                return unit;
            throw new Exception("Error parsing unit");
        }

        public static IList<int> ParseUnits(IList<string> lines)
        {
            var units = new List<int>();
            foreach (var line in lines)
            {
                if (int.TryParse(line, out var unit))
                    units.Add(unit);
                throw new Exception("Error parsing unit");
            }
            
            return units;
        }
    }
}
