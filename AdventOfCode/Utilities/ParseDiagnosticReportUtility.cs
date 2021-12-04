using AdventOfCode.Utilities;
using System.Collections;
using System.Text;

namespace AdventOfCode
{
    public static class ParseDiagnosticReportUtility
    {
        public static IList<BitArray> ParseDiagnosticReport(List<string> fileLines)
        {            
            var diagnosticReport = new List<BitArray>();

            foreach (string line in fileLines)
                diagnosticReport.Add(new BitArray(line.Select(c => c == '1').ToArray()));

            return diagnosticReport;
        }
    }
}