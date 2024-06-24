
//input
int dayMissing = int.Parse(Console.ReadLine());
int foodOverall =  int.Parse(Console.ReadLine());

double foodForDogPerDay = double.Parse(Console.ReadLine());
double foodForCatPerDay = double.Parse(Console.ReadLine());
double foodForTurtlePerDay = double.Parse(Console.ReadLine());

//calculations
//double foodForTurtlePerDayKG = foodForTurtlePerDay / 1000;
double foodNeeded = (foodForDogPerDay + foodForCatPerDay + foodForTurtlePerDay/1000) * dayMissing;

double difference = Math.Abs(foodOverall - foodNeeded);

// output
if (foodOverall >= foodNeeded)
{
    Console.WriteLine($"{Math.Floor(difference)} kilos of food left.");
}
else
{
    Console.WriteLine($"{Math.Ceiling(difference)} more kilos of food are needed.");
}