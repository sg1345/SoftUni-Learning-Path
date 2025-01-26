namespace LineNumbers
{
    using System.Diagnostics.Metrics;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using(var reader = new StreamReader(inputFilePath))
            {
                using(var writer = new StreamWriter(outputFilePath))
                {
                    string line = reader.ReadLine();
                    int count = 0;
                    while (line != null)
                    {
                        count++;
                        writer.WriteLine($"{count}. {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
