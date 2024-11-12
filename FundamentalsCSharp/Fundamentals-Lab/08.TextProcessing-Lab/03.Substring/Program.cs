internal class Program
{
    static void Main()
    {
        string remover = Console.ReadLine();

        string text = Console.ReadLine();

        while (text.Contains(remover))
        {
            int startIndexRemover = text.IndexOf(remover);
            text = text.Remove(startIndexRemover, remover.Length);
        }

        Console.WriteLine(text);
    }
}