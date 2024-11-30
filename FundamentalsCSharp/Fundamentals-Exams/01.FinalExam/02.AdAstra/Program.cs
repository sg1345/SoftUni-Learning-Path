using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string information = Console.ReadLine();
        string pattern = @"([#\|])(?<name>[A-Za-z ]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

        MatchCollection foods = Regex.Matches(information, pattern);

        int calories = 0;
        foreach (Match food in foods)
        {
            calories += int.Parse(food.Groups["calories"].Value);
        }

        int days = calories/2000;

        Console.WriteLine($"You have food to last you for: {days} days!");

        foreach (Match food in foods)
        {
            Console.WriteLine
                (
                    $"Item: {food.Groups["name"].Value}," +
                    $" Best before: {food.Groups["date"].Value}," +
                    $" Nutrition: {food.Groups["calories"].Value}"
                );
        }

    }
}
