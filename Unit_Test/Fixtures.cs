using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test
{
    public class Fixtures
    {
        public string Name { get; set; }
        public string inputFilePath { get; set; }
        public string outputFilePath { get; set; }
        public int? firstXLines { get; set; }
        public int? lastYLines { get; set; }
        public bool ExpectedResult { get; set; }
        public Type ExpectedException { get; set; }

        public static object[][] TestData = new object[][]
        {
            new object[]
            {
                new Fixtures
                {
                    Name = "Convert first X lines",
                    inputFilePath = "D:/input_data.csv",
                    outputFilePath = "D:/output_data.tsv",
                    firstXLines = 2,
                    lastYLines = null,
                    ExpectedResult = true,
                    ExpectedException = null
                }
            },
            new object[]
            {
                new Fixtures
                {
                    Name = "Convert last Y lines",
                    inputFilePath = "D:/input_data.csv",
                    outputFilePath = "D:/output_data.tsv",
                    firstXLines = null,
                    lastYLines = 2,
                    ExpectedResult = true,
                    ExpectedException = null
                }
            },
            new object[]
            {
                new Fixtures
                {
                    Name = "When input file path is not valid",
                    inputFilePath = "D:/input_data.cvs",
                    outputFilePath = "D:/output_data.tsv",
                    firstXLines = 2,
                    lastYLines = null,
                    ExpectedResult = false,
                    ExpectedException = typeof(FileNotFoundException)
                }
            }
        };
    }
}
