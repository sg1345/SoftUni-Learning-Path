internal class Program
{
    static void Main()
    {
        Dictionary<string, int> resourceQuantity = new();

        string input = string.Empty;
        while((input = Console.ReadLine()) != "stop")
        {
            int quantity = int.Parse(Console.ReadLine());

            if (resourceQuantity.ContainsKey(input))
            {
                resourceQuantity[input] += quantity;
                continue;
            }

            resourceQuantity.Add(input, quantity);
        }

        foreach(KeyValuePair<string, int> resource in resourceQuantity)
        {
            Console.WriteLine($"{resource.Key} -> {resource.Value}");
        }
    }
}