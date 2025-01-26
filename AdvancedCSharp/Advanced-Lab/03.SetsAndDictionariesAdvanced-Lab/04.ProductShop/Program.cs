internal class Program
{
    static void Main()
    {
        //supermarket -> product -> price
        Dictionary<string, Dictionary<string, double>> productShop = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Revision")
        {
            string[] command = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string supermarket = command[0];
            string product = command[1];
            double price = double.Parse(command[2]);

            if (!productShop.ContainsKey(supermarket))
            {
                productShop[supermarket] = new();
            }

            productShop[supermarket].Add(product, price);
        }

        productShop = productShop.OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (var (supermarket, products) in productShop)
        {
            Console.WriteLine($"{supermarket}->");
            foreach (var (product, price) in products)
            {
                Console.WriteLine($"Product: {product}, Price: {price}");
            }
        }
    }
}