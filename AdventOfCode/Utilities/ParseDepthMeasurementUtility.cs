namespace AdventOfCode
{
    public class ParseDepthMeasurementUtility
    {
        private static IList<DepthMeasurement> processedDepthMeasurements = new List<DepthMeasurement>();

        public static IList<DepthMeasurement> ParseDepths(IList<string> fileLines)
        {
            foreach (var line in fileLines)
            {
                var depthMeasurement = new DepthMeasurement
                {
                    Unit = ParseUnit(line)
                };

                depthMeasurement.ChangeInUnit = CalculateChange(depthMeasurement.Unit);
                processedDepthMeasurements.Add(depthMeasurement);
            }

            CalculateSlidingUnits();

            return processedDepthMeasurements;
        }

        private static int ParseUnit(string line)
        {
            if (int.TryParse(line, out var unit))
                return unit;
            throw new Exception("Error parsing unit");
        }

        private static int CalculateChange(int depthMeasurementUnit)
        {
            if (processedDepthMeasurements.Count < 1)
                return 0;

            return depthMeasurementUnit - processedDepthMeasurements[processedDepthMeasurements.Count - 1].Unit;
        }

        private static void CalculateSlidingUnits()
        {
            for (int i = 0; i < processedDepthMeasurements.Count; i ++)
            {
                processedDepthMeasurements[i].SlidingUnit = CalculateSlidingUnit(i);
                processedDepthMeasurements[i].ChangeInSlidingUnit = CalculateSlidingChange(i);
            }
        }

        private static int CalculateSlidingUnit(int index)
        {
            var slidingUnit = processedDepthMeasurements[index].Unit;

            if (index < processedDepthMeasurements.Count - 1)
                slidingUnit += processedDepthMeasurements[index + 1].Unit;

            if (index < processedDepthMeasurements.Count - 2)
                slidingUnit += processedDepthMeasurements[index + 2].Unit;

            return slidingUnit;
        }

        private static int CalculateSlidingChange(int index)
        {
            if (index < 1)
                return 0;

            return processedDepthMeasurements[index].SlidingUnit - processedDepthMeasurements[index - 1].SlidingUnit;
        }
    }
}