namespace AdventOfCode
{
    public static class ReadTextFileUtility
    {
        public static IList<string> ReadFileAsLines(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }
    }
}
