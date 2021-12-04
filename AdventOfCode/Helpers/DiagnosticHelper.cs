using System.Collections;

namespace AdventOfCode
{
    public static class DiagnosticHelper
    {
        private static BitArray gammaRate = new(12);
        private static BitArray epsilonRate = new(12);

        public static int GetPowerConsumption(IList<BitArray> parsedDiagnosticReport)
        {
            CalculateRates(parsedDiagnosticReport);

            var gammaRateToDecimal = ConvertRateToInt(gammaRate);
            var epsilonRateToDecimal = ConvertRateToInt(epsilonRate);

            return gammaRateToDecimal * epsilonRateToDecimal;
        }

        private static void CalculateRates(IList<BitArray> report)
        {
            var halfBinaryCount = report.Count / 2;
            
            gammaRate = new BitArray(12);
            epsilonRate = new BitArray(12);

            for (int i = 0; i < 12; i++)
            {
                gammaRate[i] = report.Where(x => x.Get(i) == true).Count() 
                    > halfBinaryCount;

                epsilonRate[i] = report.Where(x => x.Get(i) == true).Count() 
                    < halfBinaryCount;
            }
        }

        private static int ConvertRateToInt(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}