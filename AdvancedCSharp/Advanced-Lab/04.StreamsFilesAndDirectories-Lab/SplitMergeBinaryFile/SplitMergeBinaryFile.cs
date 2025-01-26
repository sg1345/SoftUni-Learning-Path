namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var inputStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (var outputStreamPartOne = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write))
            using (var outputStreamPartTwo = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write))
            {
                int firstPartSize = (int)(inputStream.Length / 2 + inputStream.Length % 2);
                Copy(inputStream, outputStreamPartOne, firstPartSize);

                int secondPartSize = (int)inputStream.Length / 2;
                Copy(inputStream, outputStreamPartTwo, secondPartSize);
            }
        }

        private static void Copy(Stream source, Stream destination, int length)
        {
            byte[] buffer = new byte[1024];
            int totalBytesRead = 0;
            while (totalBytesRead < length)
            {
                int currentByteRead = source.Read(buffer, 0, Math.Min(buffer.Length, length - totalBytesRead));
                destination.Write(buffer, 0, currentByteRead);

                totalBytesRead += currentByteRead;
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var inputStreamFirstPart = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
            using (var inputStreamSecondPart = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
            using (var outputStream = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                inputStreamFirstPart.CopyTo(outputStream);
                inputStreamSecondPart.CopyTo(outputStream);
            }
        }
    }
}