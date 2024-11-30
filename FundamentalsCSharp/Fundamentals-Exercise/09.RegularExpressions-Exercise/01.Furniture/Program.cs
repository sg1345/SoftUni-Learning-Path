using System.Text.RegularExpressions;

public class Furniture
{
    public Furniture(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal Total
    {
        get { return Price * Quantity; }
    }
}

internal class Program
{
    static void Main()
    {
        string pattern = @">>(?<name>[A-z]+)<<(?<price>\d+\.?\d+)\!(?<quantity>\d+)";

        List<Furniture> furnitures = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Purchase")
        {
            Match match = Regex.Match(input, pattern);

            if (!match.Success)
            {
                continue;
            }

            Furniture furniture = new
                (
                    match.Groups["name"].Value,
                    decimal.Parse(match.Groups["price"].Value),
                    int.Parse(match.Groups["quantity"].Value)
                );


            furnitures.Add(furniture);
        }

        Console.WriteLine("Bought furniture:");
        decimal totalSpend = 0m;

        foreach (Furniture furniture in furnitures)
        {
            Console.WriteLine(furniture.Name);

            totalSpend += furniture.Total;
        }
        Console.WriteLine($"Total money spend: {totalSpend:f2}");
    }
}