using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<quantity>\d+)\|[A-Za-z]{0,}(?<price>\d+\.?\d+)\$";

        decimal total = 0m;

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end of shift")
        {
            Match match = Regex.Match(input, pattern);

            if (!match.Success)
            {
                continue;
            }

            decimal productPrice = int.Parse(match.Groups["quantity"].Value) * decimal.Parse(match.Groups["price"].Value);

            total += productPrice;

            Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {productPrice:f2}");
        }

        Console.WriteLine($"Total income: {total:f2}");
    }
}

