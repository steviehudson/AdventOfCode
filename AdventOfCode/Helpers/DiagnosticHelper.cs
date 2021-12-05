using AdventOfCode.Utilities;
using System.Collections;
using System.Text;

namespace AdventOfCode
{
    public static class DiagnosticHelper
    {
        private static BitArray gammaRate = new(12);
        private static BitArray epsilonRate = new(12);
        private static BitArray oxygenGeneratorRating = new(12);
        private static BitArray carbonDioxideScrubberRating = new(12);

        public static decimal GetPowerConsumption(IList<BitArray> parsedDiagnosticReport)
        {
            CalculateRates(parsedDiagnosticReport);

            var gammaRateToDecimal= ConvertRateToDecimal(gammaRate);
            var epsilonRateToDecimal = ConvertRateToDecimal(epsilonRate);

            return gammaRateToDecimal * epsilonRateToDecimal;
        }

        public static decimal GetLifeSupportRating(IList<BitArray> parsedDiagnosticReport)
        {
            CalculateRates(parsedDiagnosticReport);
            CalculateRatings(parsedDiagnosticReport);

            var oxygenGeneratorRatingToDecimal = ConvertRateToDecimal(oxygenGeneratorRating);
            var carbonDioxideScrubberRatingToDecimal = ConvertRateToDecimal(carbonDioxideScrubberRating);

            return oxygenGeneratorRatingToDecimal * carbonDioxideScrubberRatingToDecimal;
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

        private static void CalculateRatings(IList<BitArray> parsedDiagnosticReport)
        {
            oxygenGeneratorRating = CalculateRating(parsedDiagnosticReport, gammaRate);
            carbonDioxideScrubberRating = CalculateRating(parsedDiagnosticReport, epsilonRate);
        }

        private static BitArray CalculateRating(IList<BitArray> ratings, BitArray rate)
        {
            var processedRatings = ratings;
            for (int i = 0; processedRatings.Count > 1; i++)
            {
                var commonBit = rate[i];
                processedRatings = processedRatings.Where(x => x.Get(i) == commonBit).ToList();
            }

            return processedRatings[0];
        }

        private static decimal ConvertRateToDecimal(BitArray bits)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < bits.Count; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return Convert.ToInt32(sb.ToString(), 2);
        }
    }
}