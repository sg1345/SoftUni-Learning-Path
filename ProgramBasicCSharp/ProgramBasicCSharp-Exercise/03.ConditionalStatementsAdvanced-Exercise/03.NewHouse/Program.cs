
string flower = Console.ReadLine();
int countFlower = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

double finalPrice = 0;

switch (flower)
{
    case "Roses":
        if (countFlower > 80)
        {
            finalPrice = countFlower * 5.00 * 0.90;
        }
        else
        {
            finalPrice = countFlower * 5.00;
        }
        break;
    case "Dahlias":
        if (countFlower > 90)
        {
            finalPrice = countFlower * 3.80 * 0.85;
        }
        else
        {
            finalPrice = countFlower * 3.80;
        }
        break;
    case "Tulips":
        if (countFlower > 80)
        {
            finalPrice = countFlower * 2.80 * 0.85;
        }
        else
        {
            finalPrice = countFlower * 2.80;
        }
        break;
    case "Narcissus":
        if (countFlower < 120)
        {
            finalPrice = countFlower * 3.00 * 1.15;
        }
        else
        {
            finalPrice = countFlower * 3.00;
        }
        break;
    case "Gladiolus":
        if (countFlower < 80)
        {
            finalPrice = countFlower * 2.50 * 1.20;
        }
        else
        {
            finalPrice = countFlower * 2.50;
        }
        break;
}
double difference = Math.Abs(budget - finalPrice);

if (budget >= finalPrice)
{
    Console.WriteLine($"Hey, you have a great garden with {countFlower} {flower} and {difference:f2} leva left.");
}
else if (budget < finalPrice)
{
    Console.WriteLine($"Not enough money, you need {difference:f2} leva more.");
}