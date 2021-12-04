namespace AdventOfCode
{
    public class DepthHelper
    {
        public static int GetIncreasedDepthsCount(IList<DepthMeasurement> parsedDepths)
        {
            return parsedDepths.Where(x => x.ChangeInUnit > 0).Count();
        }

        public static int GetIncreasedSlidingDepthsCount(IList<DepthMeasurement> parsedDepths)
        {
            return parsedDepths.Where(x => x.ChangeInSlidingUnit > 0).Count();
        }
    }
}