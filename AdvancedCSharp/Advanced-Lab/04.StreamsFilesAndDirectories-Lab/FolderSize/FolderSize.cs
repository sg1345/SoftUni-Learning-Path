namespace FolderSize
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            Queue<string> queue = new();
            queue.Enqueue(folderPath);

            long totalSize = 0;
            while (queue.Count > 0)
            {
                string currentFolder = queue.Dequeue();
                
                var files = Directory.GetFiles(currentFolder);
                foreach ( string file in files )
                {
                    FileInfo fileInfo = new FileInfo(file);
                    totalSize += fileInfo.Length;
                }

                var subFolders = Directory.GetDirectories(currentFolder);
                foreach( string subFolder in subFolders)
                {
                    queue.Enqueue(subFolder);
                }
            }

            File.WriteAllText(outputFilePath, $"{(double)totalSize/1024} KB");
        }
    }
}
