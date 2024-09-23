using ClassLibrary;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Enter the input and output paths to read and write the data
            Console.Write("Enter the input CSV file path: ");
            string inputFilePath = Console.ReadLine();
            Console.Write("Enter the output TSV file path: ");
            string outputFilePath = Console.ReadLine();

            Console.Write("Do you want to convert the first X lines or last Y lines? (Enter 'first' or 'last'): ");
            string option = Console.ReadLine()?.ToLower();

            int? firstXLines = null;
            int? lastYLines = null;

            if (option == "first")
            {
                Console.Write("Enter the number of first X lines to convert: ");
                if (int.TryParse(Console.ReadLine(), out int x))
                {
                    firstXLines = x;
                }
            }
            else if (option == "last")
            {
                Console.Write("Enter the number of last Y lines to convert: ");
                if (int.TryParse(Console.ReadLine(), out int y))
                {
                    lastYLines = y;
                }
            }
            try
            {
                Conversion.ConvertCSVtoTSV(inputFilePath, outputFilePath, firstXLines, lastYLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine($"Successfully converted {inputFilePath} to {outputFilePath}");
        }
    }
}