namespace CloudDrive
{
    public class File
    {
        public File(string name, string extension, int size)
        {
            this.Name = name;
            this.Extension = extension;
            this.Size = size;
        }

        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }

        public override string ToString()
        {
            return $"File: '{this.Name}.{this.Extension}' - {this.Size}KB";
        }
    }
}
