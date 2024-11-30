using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";

        MatchCollection matchedNames = Regex.Matches(text, pattern);

        foreach (Match match in matchedNames)
        {
            Console.Write($"{match.Value} ");
        }
    }
}