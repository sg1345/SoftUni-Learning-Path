namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] files = Directory.GetFiles(inputPath, "*.*", SearchOption.TopDirectoryOnly);
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);
           

            foreach (string file in files)
            {
                using (FileStream inputCurrentFile = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    string fileName = Path.GetFileName(file);
                    string outputFilePath = Path.Combine(outputPath, fileName);
                    File.Copy(file, outputFilePath, overwrite: true);
                }
            }            
        }
    }
}
