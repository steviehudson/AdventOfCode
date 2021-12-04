namespace AdventOfCode
{
    public static class ProcessDays
    {
        public static void ProcessDayOne()
        {
            var fileLines = ReadTextFileUtility.ReadFileAsLines("Resources\\DayOne.txt");
            var parsedDepths = ParseDepthMeasurementUtility.ParseDepths(fileLines);
            var increasedDepthsCount = DepthHelper.GetIncreasedDepthsCount(parsedDepths);
            var increasedSlidingDepthsCount = DepthHelper.GetIncreasedSlidingDepthsCount(parsedDepths);

            Console.WriteLine($"Day One > Task One - {increasedDepthsCount}");
            Console.WriteLine($"Day One > Task Two - {increasedSlidingDepthsCount}");
        }

        public static void ProcessDayTwo()
        {
            var fileLines = ReadTextFileUtility.ReadFileAsLines("Resources\\DayTwo.txt");
            var parsedCommands = ParseSubmarineCommandsUtility.ParseCommands(fileLines);
            var overallPositionWithoutAim = PositionHelper.GetOverallPositionWithoutAim(parsedCommands);
            var overallPositionWithAim = PositionHelper.GetOverallPositionWithAim(parsedCommands);

            Console.WriteLine($"Day Two > Task One - {overallPositionWithoutAim}");
            Console.WriteLine($"Day Two > Task Two - {overallPositionWithAim}");
        }

        public static void ProcessDayThree()
        {
            return;
        }


    }
}
