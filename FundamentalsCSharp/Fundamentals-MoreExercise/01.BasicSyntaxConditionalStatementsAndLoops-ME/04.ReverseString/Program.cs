internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        string reverseText = string.Empty;

        for (int i = text.Length - 1; i >= 0; i--)
        {
            reverseText += text[i];
        }

        Console.WriteLine(reverseText);
    }
}

