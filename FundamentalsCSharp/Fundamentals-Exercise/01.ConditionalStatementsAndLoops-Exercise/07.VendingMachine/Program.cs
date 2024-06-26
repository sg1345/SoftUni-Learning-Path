internal class Program
{
    static void Main()
    {
        var money = 0.0;
            
        while (true) 
        {
            var input = Console.ReadLine();

            if (input == "Start") 
            {
                break;
            }
            var coin = double.Parse(input);

            if (coin == 2.0)
            {
                money += 2.0;
            }
            else if (coin == 1.00)
            {
                money += 1.00;
            }
            else if (coin == 0.50)
            {
                money += 0.50;
            }
            else if (coin == 0.20)
            {
                money += 0.20;
            }
            else if (coin == 0.10)
            {
                money += 0.10;
            }
            else 
            {
                Console.WriteLine($"Cannot accept {coin}");
            }
        }

        while (true)
        {
            bool isInvalid = false;
            var input = Console.ReadLine();

            var price = 0.0;

            if(input == "End")
            {
                break;
            }

            if (input == "Nuts")
            {
                input = "nuts";
                price = 2.00;
            }
            else if (input == "Water")
            {
                input = "water";
                price = 0.70;
            }
            else if (input == "Crisps")
            {
                input = "crisps";
                price = 1.50;
            }
            else if (input == "Soda")
            {
                input = "soda";
                price = 0.80;
            }
            else if (input == "Coke")
            {
                input = "coke";
                price = 1.00;
            }
            else
            {
                isInvalid = true;
                Console.WriteLine("Invalid product");
            }

            if (money - price < 0)
            {
                Console.WriteLine("Sorry, not enough money");
            }
            else if (!isInvalid)
            {
                Console.WriteLine($"Purchased {input}");
                money -= price;
            }
        }

        Console.WriteLine($"Change: {money:F2}");
    }
}