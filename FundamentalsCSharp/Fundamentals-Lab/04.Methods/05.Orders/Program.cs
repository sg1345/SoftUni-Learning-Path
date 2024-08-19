
internal class Program
{
    static void Main()
    {
        string product = Console.ReadLine();
        var quantity = int.Parse(Console.ReadLine());

        PrintTotal(product,quantity);

    }

    static void PrintTotal(string product, int quantity)
    {
        var total = 0d;

        switch (product)
        {
            case "coffee":
                total = quantity * 1.50;
                break;
            case "water":
                total = quantity * 1.00;
                break;
            case "coke":
                total = quantity * 1.40;
                break;
            case "snacks":
                total = quantity * 2.00;
                break;
        }
        Console.WriteLine($"{total:F2}");
    }
}