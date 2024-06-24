
int age = int.Parse(Console.ReadLine());
double priceWashingMachine = double.Parse(Console.ReadLine());
int priceToy = int.Parse(Console.ReadLine());

int countToys = 0;
int moneyGathered = 0;
int countEvenAge = 0; 

for (int i = 1; i <= age; i++)
{
    if (i%2 == 1)
    {
        countToys++;
    }
    else if (i%2 == 0)
    {
        countEvenAge++;
        moneyGathered += 10 * countEvenAge - 1;
    }
}

moneyGathered += countToys * priceToy;

double difference = Math.Abs(moneyGathered-priceWashingMachine);

if (moneyGathered >= priceWashingMachine)
{
    Console.WriteLine($"Yes! {difference:f2}");
}
else if (moneyGathered < priceWashingMachine)
{
    Console.WriteLine($"No! {difference:f2}");
}