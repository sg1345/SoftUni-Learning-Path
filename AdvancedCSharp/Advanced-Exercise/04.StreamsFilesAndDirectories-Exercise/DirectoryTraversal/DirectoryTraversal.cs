namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*.*", SearchOption.TopDirectoryOnly);

            Dictionary<string, Dictionary<string, double>> fileProperties = new();

            foreach (string file in files)
            {
                //string fileName = file.Remove(0, inputFolderPath.Length + 1);

                string extension = Path.GetExtension(file);

                string name = Path.GetFileName(file);

                FileInfo fileInfo = new FileInfo(file);
                double size = (double)fileInfo.Length / 1024;

                if (!fileProperties.ContainsKey(extension))
                {
                    fileProperties[extension] = new();
                }

                fileProperties[extension].Add(name, size);
            }

            Dictionary<string, Dictionary<string, double>> filteredFileProperties = new();

            filteredFileProperties = fileProperties.OrderByDescending(extension => extension.Value.Count)
                .ThenBy(extension => extension.Key)
                .ToDictionary
                (
                extension => extension.Key,

                fileInfo => fileInfo.Value.OrderBy(inner => inner.Key)
                .ToDictionary(inner => inner.Key, inner => inner.Value)
                );

            string result = string.Empty;
            foreach (var (extension, FileInfo) in filteredFileProperties)
            {
                result += $"{extension} \n";
                foreach (var (name, size) in FileInfo)
                {
                    result += $"--{name} - {size:f3}kb\n";
                }
            }

            //Console.WriteLine(result);
            return result;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathToOutput = Environment.GetFolderPath
                (Environment.SpecialFolder.Desktop) + reportFileName;

            using (StreamWriter writer = new StreamWriter(pathToOutput))
            {
                writer.WriteLine(textContent);
            }
        }
    }
}
