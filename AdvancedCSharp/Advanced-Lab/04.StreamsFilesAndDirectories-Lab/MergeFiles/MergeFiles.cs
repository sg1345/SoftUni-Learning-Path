namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var readerFirstLine = new StreamReader(firstInputFilePath))
            {

                using (var readerSecondLine = new StreamReader(secondInputFilePath))
                {
                    using(var writer = new StreamWriter(outputFilePath))
                    {
                        string firstLine = readerFirstLine.ReadLine();
                        string secondLine = readerSecondLine.ReadLine();

                        while (firstLine != null || secondLine != null)
                        {
                            if (firstLine != null)
                            {
                                writer.WriteLine(firstLine);
                            }

                            if (secondLine != null)
                            {
                                writer.WriteLine(secondLine);
                            }

                            firstLine = readerFirstLine.ReadLine();
                            secondLine = readerSecondLine.ReadLine();
                        }

                    }
                }
            }
        }
    }
}
