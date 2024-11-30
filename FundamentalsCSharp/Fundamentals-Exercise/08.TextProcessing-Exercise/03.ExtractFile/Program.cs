internal class Program
{
    static void Main()
    {
        string[] filePath = Console.ReadLine().Split('\\');

        string[] fileName = filePath[filePath.Length - 1].Split('.');

        Console.WriteLine($"File name: {fileName[0]}");
        Console.WriteLine($"File extension: {fileName[1]}");
    }
}