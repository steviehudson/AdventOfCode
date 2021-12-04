namespace AdventOfCode
{
    public static class ReadTextFileUtility
    {
        public static List<string> ReadFileAsLines(string fileName)
        {
            return File.ReadAllLines(fileName).ToList();
        }
    }
}
