using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"\+359([ -])2\1\d{3}\1\d{4}\b";

        MatchCollection phoneNumbers = Regex.Matches(input, pattern);

        string result = string.Empty;
        foreach (Match number in phoneNumbers)
        {
            result += $" {number.Value},";
        }

        Console.WriteLine(result.TrimEnd(',').TrimStart());
    }
}