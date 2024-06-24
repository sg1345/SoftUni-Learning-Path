//input
double budget = double.Parse(Console.ReadLine());
int countVideoCards = int.Parse(Console.ReadLine());
int countCPU = int.Parse(Console.ReadLine());
int countRAM = int.Parse(Console.ReadLine());

//calculations
double totalVideoCards = countVideoCards * 250;

double pricePerCPU = totalVideoCards * 0.35;
double pricePerRAM = totalVideoCards * 0.1;

double totalCPU = countCPU * pricePerCPU;
double totalRAM = countRAM * pricePerRAM;

double totalPrice;

if ( countVideoCards > countCPU)
{
    totalPrice = totalRAM + totalVideoCards + totalCPU;
    totalPrice *= 0.85;

}
else
{
    totalPrice = totalRAM + totalVideoCards + totalCPU;

}

double difference = Math.Abs(budget - totalPrice);

//output
if( totalPrice <= budget)
{
    Console.WriteLine($"You have {difference:F2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {difference:F2} leva more!");
}