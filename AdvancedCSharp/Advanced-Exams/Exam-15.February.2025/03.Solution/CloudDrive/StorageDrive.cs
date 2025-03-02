using System.Linq;
using System.Text;

namespace CloudDrive
{
    public class StorageDrive
    {
        public StorageDrive(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Files = new List<File>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<File> Files { get; set; }

        public void AddFile(File file)
        {
            int neededCapacity = this.Files.Select(f => f.Size).Sum() + file.Size;

            if (this.Capacity < neededCapacity)
            {
                return;
            }

            if (this.Files.Any(f => f.Name == file.Name && f.Extension == file.Extension))
            {
                return;
            }

            this.Files.Add(file);
        }

        public bool DeleteFile(string name, string extension)
            => this.Files.Remove(this.Files.FirstOrDefault(f => f.Name == name && f.Extension == extension)!);

        public File GetLargestFile()
            => this.Files.OrderByDescending(f => f.Size).FirstOrDefault()!;

        public string GetFileDetails(string name, string extension)
        {
            if (this.Files.Any(f => f.Name == name && f.Extension == extension))
            {
                return this.Files
                .ElementAt(this.Files.FindIndex(f => f.Name == name && f.Extension == extension)!)
                .ToString();
            }

            return "File not found!";

        }
        public int GetFilesCount()
            => this.Files.Count();

        public List<File> GetFilesByType(string extension)
            => this.Files.Where(f => f.Extension == extension).OrderBy(f => f.Size).ToList();

        public string StorageReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Storage Drive: {this.Name}");

            foreach (File file in this.Files.OrderBy(f => f.Size).ToList())
            {
                sb.AppendLine(file.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
