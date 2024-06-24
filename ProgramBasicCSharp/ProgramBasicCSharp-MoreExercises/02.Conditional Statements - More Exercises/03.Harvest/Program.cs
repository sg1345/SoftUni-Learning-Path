//input
int areaLoze = int.Parse(Console.ReadLine());
double grozdePerSquareMeter = double.Parse(Console.ReadLine());
int wineNeeded = int.Parse(Console.ReadLine());
int countWorkers =  int.Parse(Console.ReadLine());

//calculations
double overallGrozde = areaLoze * grozdePerSquareMeter;
double wine = overallGrozde * 0.40 / 2.5;

if (wineNeeded <= wine )
{
    double wineLeft = wine - wineNeeded;
    double winePerPerson = wineLeft / countWorkers;
    Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
    Console.WriteLine($"{Math.Ceiling(wineLeft)} liters left -> {Math.Ceiling(winePerPerson)} liters per person.");
}
else
{
    double wineMissing = wineNeeded - wine;
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineMissing)} liters wine needed.");
}