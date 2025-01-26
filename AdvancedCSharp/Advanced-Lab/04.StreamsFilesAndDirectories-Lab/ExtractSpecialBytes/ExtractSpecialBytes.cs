namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (var inputStream = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            using (var bytePath = new StreamReader(bytesFilePath))
            using (var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                HashSet<byte> bytes = bytePath.ReadToEnd()
                    .Split('\n',StringSplitOptions.RemoveEmptyEntries)
                    .Select(byte.Parse)
                    .ToHashSet();

                byte[] buffer = new byte[1024];
                int bytesRead; 

                while ((bytesRead = inputStream.Read(buffer)) != 0)
                {
                    int bufferCount = 0;

                    for (int i = 0; i < bytesRead; i++)
                    {
                        if (bytes.Contains(buffer[i]))
                        {
                            buffer[bufferCount++] = buffer[i];
                        }
                    }

                    outputStream.Write(buffer, 0, bufferCount);
                }
            }
        }
    }
}
