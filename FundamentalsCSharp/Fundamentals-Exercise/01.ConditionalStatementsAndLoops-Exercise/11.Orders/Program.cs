using System.Diagnostics;

internal class Program
{
    static void Main()
    {   
        var numberOfOrders =int.Parse(Console.ReadLine());

        var total = 0.00;

        for (int order = 1; order <= numberOfOrders; order++)
        {
            var pricePerCapsule = double.Parse(Console.ReadLine());
            var daysInMonth = int.Parse(Console.ReadLine());
            var capsulesCount = int.Parse(Console.ReadLine());

            var orderPrice = ((daysInMonth * capsulesCount) * pricePerCapsule);

            Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");

            total += orderPrice;
        }

        Console.WriteLine($"Total: ${total:f2}");
    }
}