using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Conversion
    {
        public static void ConvertCSVtoTSV(string? inputFilePath, string? outputFilePath, int? firstXLines, int? lastYLines)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException("The input file does not exist.");
                //Console.WriteLine("The input file does not exist. Please check the path and try again.");
                //return;
            }

            var lines = File.ReadAllLines(inputFilePath);
            IEnumerable<string> selectedLines = lines;

            if (firstXLines.HasValue)
            {
                selectedLines = selectedLines.Take(firstXLines.Value);
            }
            else if (lastYLines.HasValue)
            {
                selectedLines = selectedLines.Skip(Math.Max(0, lines.Length - lastYLines.Value));
            }
            var tsvLines = selectedLines.Select(line => line.Replace(",", "\t"));
            File.WriteAllLines(outputFilePath, tsvLines);
        }
    }
}
