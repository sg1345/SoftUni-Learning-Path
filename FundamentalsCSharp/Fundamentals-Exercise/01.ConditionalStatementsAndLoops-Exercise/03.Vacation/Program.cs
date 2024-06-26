internal class Program
{
    static void Main()
    {
        var people = int.Parse(Console.ReadLine());
        var typeOfGroup = Console.ReadLine();
        var day = Console.ReadLine();

        var Total = 0.0;
        var price = 0.00;
        switch (typeOfGroup)
        {
            
            case   "Students":
                if (day == "Friday")
                {
                price = 8.45;
                }
                else if (day == "Saturday")
                {
                price = 9.80;
                }
                else if (day == "Sunday")
                {
                price = 10.46;
                }

                Total = price * people;

                if (people >= 30)
                {
                    Total *= 0.85;
                }

                break;

            case "Business":
                if (day == "Friday")
                {
                price = 10.90;
                }
                else if (day == "Saturday")
                {
                price = 15.60;
                }
                else if (day == "Sunday")
                {
                price = 16.00;
                }

                Total = price * people;

                if (people >= 100)
                {
                Total -= (10 * price);
                }

                break;

            case   "Regular":
                if (day == "Friday")
                {
                price = 15.00;
                }
                else if (day == "Saturday")
                {
                price = 20.00;
                }
                else if (day == "Sunday")
                {
                price = 22.50;
                }

                Total = price * people;

                if (people >=10 && people <= 20)
                {
                Total *= 0.95;
                }

                break;

        }

        Console.WriteLine($"Total price: {Total:F2}");
    }
}