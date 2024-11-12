class Prices
{
    public Prices(decimal price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }
    public decimal Price;
    public int Quantity;
}

internal class Program
{
    static void Main()
    {
        Dictionary<string, Prices> productsPrices = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] productInfo = input.Split();

            string product = productInfo[0];
            decimal pricePerProduct = decimal.Parse(productInfo[1]);
            int quantity = int.Parse(productInfo[2]);

            if (productsPrices.ContainsKey(product))
            {
                productsPrices[product].Quantity += quantity;
                productsPrices[product].Price = pricePerProduct;
                continue;
            }

            productsPrices[product] = new(pricePerProduct,quantity);
        }

        foreach (KeyValuePair<string, Prices> prodocutPrice in productsPrices)
        {
            decimal finalPrice = prodocutPrice.Value.Price * prodocutPrice.Value.Quantity;

            Console.WriteLine($"{prodocutPrice.Key} -> {finalPrice:f2}");
        }
    }
}