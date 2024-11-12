internal class Program
{
    static void Main()
    {
        string[] banWords = Console.ReadLine()
            .Split(',')
            .Select(word => word.Trim())
            .ToArray();

        string text = Console.ReadLine();

        foreach (string word in banWords)
        {
            string replacement = new string('*',word.Length);

            text = text.Replace(word, replacement);
        }

        Console.WriteLine(text);
    }
}