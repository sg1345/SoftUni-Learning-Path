//input
double budgetOfMovie = double.Parse(Console.ReadLine());
int statists = int.Parse(Console.ReadLine());
double pricePerCostume = double.Parse(Console.ReadLine());

//calculcations
double decor = budgetOfMovie * 0.1;
double priceAllCostumes;

if(statists > 150)
{
    priceAllCostumes = statists * pricePerCostume * 0.9;
}
else
{
    priceAllCostumes = statists * pricePerCostume;
}

double totalPriceMovie =  priceAllCostumes +decor;
double balance = Math.Abs(budgetOfMovie - totalPriceMovie);

if(budgetOfMovie >= totalPriceMovie)
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {balance:F2} leva left.");
}
else
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {balance:F2} leva more.");
}