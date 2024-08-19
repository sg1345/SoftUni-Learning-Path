
internal class Program
{
    static void Main()
    {
        var text = Console.ReadLine();

        PrintMiddleCharecters(text);
    }

    static void PrintMiddleCharecters(string text)
    {
        var middlePosition = text.Length / 2;
        
        if(text.Length % 2 == 0)
        {
            Console.WriteLine($"{text[middlePosition - 1]}{text[middlePosition]}");
        }
        else
        {
            Console.WriteLine(text[middlePosition]);
        }
    }
}