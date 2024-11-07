internal class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split().Where(words => words.Length % 2 == 0).ToArray();

        Console.WriteLine(string.Join("\n", words));
    }
}