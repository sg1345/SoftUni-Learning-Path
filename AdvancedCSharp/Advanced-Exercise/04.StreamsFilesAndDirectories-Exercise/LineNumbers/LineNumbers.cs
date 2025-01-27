namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line = string.Empty;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;

                    string patternPunctuation = @"[\.\,\-\!\?\']";
                    MatchCollection Puntuations = Regex.Matches(line, patternPunctuation);

                    string patternLetters = @"[A-Za-z]";
                    MatchCollection Letters = Regex.Matches(line, patternLetters);

                    writer.WriteLine($"Line {count}: {line} ({Letters.Count})({Puntuations.Count})");

                }
            }            
        }
    }
}
