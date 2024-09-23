using ClassLibrary;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Unit_Test
{
    public class XUnitTest
    {
        #region Convert first X lines using Fact
        [Fact]
        public void ConvertCsvToTsv_ConvertsFirstXLinesSuccessfully()
        {
            // Arrange
            string inputFilePath = "D:/input_data.csv";
            string outputFilePath = "D:/output_data.tsv";

            // Act
            Conversion.ConvertCSVtoTSV(inputFilePath, outputFilePath, firstXLines: 2, lastYLines: null);

            // Assert
            var tsvOutput = File.ReadAllLines(outputFilePath);
            Assert.Equal(2, tsvOutput.Length);
            Assert.Equal("Name\tAge\tOccupation", tsvOutput[0]);
            Assert.Equal("John Doe\t28\tEngineer", tsvOutput[1]);
        }
        #endregion

        #region Convert first Y lines using Fact
        [Fact]
        public void ConvertCsvToTsv_ConvertsFirstYLinesSuccessfully()
        {
            // Arrange
            string inputFilePath = "D:/input_data.csv";
            string outputFilePath = "D:/output_data.tsv";

            // Act
            Conversion.ConvertCSVtoTSV(inputFilePath, outputFilePath, firstXLines: null, lastYLines: 2);

            // Assert
            var tsvOutput = File.ReadAllLines(outputFilePath);
            Assert.Equal(2, tsvOutput.Length);
            Assert.Equal("Laura Adams\t31\tArchitect", tsvOutput[0]);
            Assert.Equal("Kevin Turner\t27\tChef", tsvOutput[1]);
        }
        #endregion

        #region If file not found using Fact 
        [Fact]
        public void ConvertCsvToTsv_FileNotFound_ThrowsFileNotFoundException()
        {
            // Arrange
            var inputFilePath = "non_existing_file.csv";
            string outputFilePath = "D:/output_data.tsv";

            // Act & Assert
            var exception = Assert.Throws<FileNotFoundException>(() =>
            Conversion.ConvertCSVtoTSV(inputFilePath, outputFilePath, firstXLines: 2, lastYLines: null));
            Assert.Equal("The input file does not exist.", exception.Message);
        }
        #endregion

        #region Conver first X or Last Y lins with Member Data
        [Theory]
        [MemberData(nameof(Fixtures.TestData), MemberType = typeof(Fixtures))]
        public void ConvertCsvToTsv_ConvertsXorYLines_withMemberData(Fixtures fixtures)
        {
            // Arrange
            string inputFilePath = fixtures.inputFilePath;
            string outputFilePath = fixtures.outputFilePath;

            // Act & Assert
            if (fixtures.ExpectedException != null)
            {
                // Expecting an exception
                var exception = Assert.Throws(fixtures.ExpectedException, () =>
                Conversion.ConvertCSVtoTSV(fixtures.inputFilePath, fixtures.outputFilePath, fixtures.firstXLines, fixtures.lastYLines));
                Assert.NotNull(exception);
            }
            else
            {
                // No exception expected, test for successful conversion
                Conversion.ConvertCSVtoTSV(fixtures.inputFilePath, fixtures.outputFilePath, fixtures.firstXLines, fixtures.lastYLines);

                // Verify that the output file exists
                Assert.True(File.Exists(fixtures.outputFilePath), $"Output file {fixtures.outputFilePath} should exist.");

                // Verify the file content (compare expected TSV format)
                var outputLines = File.ReadAllLines(fixtures.outputFilePath);
                Assert.All(outputLines, line => Assert.DoesNotContain(",", line));

                // Verify overall success
                Assert.True(fixtures.ExpectedResult);
            }
        }
        #endregion
    }
}