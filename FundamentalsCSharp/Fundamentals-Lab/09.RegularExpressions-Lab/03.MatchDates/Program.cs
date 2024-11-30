using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        string pattern = @"\b(?<day>\d{2})(?<separator>[\/\.\-])(?<month>[A-Z][a-z]{2})\<separator>(?<year>\d{4})\b";

        MatchCollection dates = Regex.Matches(text, pattern);

        foreach (Match date in dates)
        {
            Console.WriteLine
                (
                    $"Day: {date.Groups["day"].Value}," +
                    $" Month: {date.Groups["month"].Value}," +
                    $" Year: {date.Groups["year"].Value}"
                );
        }
    }
}