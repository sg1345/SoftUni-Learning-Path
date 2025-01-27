namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }

            

            DirectoryInfo folderInfo = Directory.GetParent(inputFilePath);
            string currentFolderName = folderInfo.FullName;
            string tempFolder = currentFolderName + @"\temp";

            if (Directory.Exists(tempFolder))
            {
                Directory.Delete(tempFolder, true);
            }

            Directory.CreateDirectory(tempFolder);

            string fileName = Path.GetFileName(inputFilePath);
            string tempInputPath = Path.Combine(tempFolder, fileName);
            File.Copy(inputFilePath, tempInputPath, overwrite: true);

           

            ZipFile.CreateFromDirectory(tempFolder, zipArchiveFilePath);
            Directory.Delete(tempFolder, true);

            //using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            //{
            //    string inputFileName = Path.GetFileName(inputFilePath);
            //    archive.CreateEntryFromFile(inputFilePath, inputFileName);    
            //}
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {

            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            //DirectoryInfo FolderInfo = Directory.GetParent(outputFilePath);
            //string currentFolderName = FolderInfo.FullName;
            
            //ZipFile.ExtractToDirectory(zipArchiveFilePath,currentFolderName);
            
            using(ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry entry = archive.GetEntry(fileName);

                if (entry != null)
                {
                    entry.ExtractToFile(outputFilePath);
                }
            }
        }
    }
}
