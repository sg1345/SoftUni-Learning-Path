//input
double trip = double.Parse(Console.ReadLine());
int countPuzzles = int.Parse(Console.ReadLine());
int countDolls = int.Parse(Console.ReadLine());
int countBears = int.Parse(Console.ReadLine());
int countMinions = int.Parse(Console.ReadLine());
int countTrucks = int.Parse(Console.ReadLine());

//calculations

double totalPricePuzzles = countPuzzles * 2.60;
double totalPriceDolls = countDolls * 3.00;
double totalPriceBears = countBears * 4.10;
double totalPriceMinions = countMinions * 8.20;
double totalPriceTrucks = countTrucks * 2;
double totalPriceAllToys = totalPricePuzzles + totalPriceDolls + totalPriceBears + totalPriceMinions + totalPriceTrucks;

int allToys = countBears + countMinions + countTrucks + countDolls + countPuzzles;

if (allToys >= 50)
{
    totalPriceAllToys *= 0.75;
}
double rent = totalPriceAllToys * 0.1;
totalPriceAllToys -= rent;
double balance = Math.Abs(totalPriceAllToys - trip);

if (totalPriceAllToys >= trip)
{
    Console.WriteLine($"Yes! {balance:F2} lv left.");
}
else
{
    Console.WriteLine($"Not enough money! {balance:F2} lv needed.");
}