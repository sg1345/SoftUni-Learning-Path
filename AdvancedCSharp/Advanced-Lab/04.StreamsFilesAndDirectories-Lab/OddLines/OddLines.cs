namespace OddLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                using (var writer = new StreamWriter(outputFilePath))
                {
                    string line = reader.ReadLine();
                    int count = 0;
                    while (line != null)
                    {
                        if (count%2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        count++;
                        line = reader.ReadLine();
                    }

                    //string[] lines = reader.ReadToEnd()
                    //    .Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries)
                    //    .Select(x => x.TrimEnd('\r'))
                    //    .ToArray();

                    //for (int i = 0; i < lines.Length; i++)
                    //{
                    //    if (i %2 == 1)
                    //    {
                    //        writer.WriteLine(lines[i]);
                    //    }
                    //}
                }
            }
        }
    }
}
