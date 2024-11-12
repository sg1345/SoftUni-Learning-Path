using System.Linq.Expressions;

internal class Program
{
    static void Main()
    {
        string text = string.Empty;

        while ((text = Console.ReadLine()) != "end")
        {
            string reversedText = new string(text.Reverse().ToArray());

            Console.WriteLine($"{text} = {reversedText}");
        }
    }
}