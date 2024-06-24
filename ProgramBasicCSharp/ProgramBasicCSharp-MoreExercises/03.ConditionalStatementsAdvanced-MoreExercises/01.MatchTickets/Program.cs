
//input
double budget = double.Parse(Console.ReadLine());
string typeOfTicket = Console.ReadLine();
int countPeople = int.Parse(Console.ReadLine());

//calculations
double ticketPrice = 0;
double transportPrice = 0;

if (typeOfTicket == "VIP") //499.99лв
{
    ticketPrice = 499.99 * countPeople;
}
else if (typeOfTicket == "Normal") //249.99лв
{
    ticketPrice = 249.99 * countPeople;
}

if (countPeople <= 4)
{
    transportPrice = budget * 0.75;
}
else if (countPeople <= 9)
{
    transportPrice = budget * 0.60;
}
else if (countPeople <= 24)
{
    transportPrice = budget * 0.50;
}
else if (countPeople <= 49)
{
    transportPrice = budget * 0.40;
}
else if (countPeople > 49)
{
    transportPrice = budget * 0.25;
}

//output
if (budget >= ticketPrice + transportPrice)
{
    Console.WriteLine($"Yes! You have {budget - ticketPrice - transportPrice:f2} leva left.");
}
else if(budget < ticketPrice + transportPrice)
{
    Console.WriteLine($"Not enough money! You need {Math.Abs(budget - ticketPrice - transportPrice):f2} leva.");

}