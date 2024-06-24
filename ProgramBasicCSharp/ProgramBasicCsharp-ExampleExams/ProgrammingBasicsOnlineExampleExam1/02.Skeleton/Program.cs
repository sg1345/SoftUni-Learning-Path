
//input
int minutes = int.Parse(Console.ReadLine());
int seconds = int.Parse(Console.ReadLine());
double lenght = double.Parse(Console.ReadLine());
int secondPer100Meters = int.Parse(Console.ReadLine());

//calculations
int minimumTimeForOlympics = minutes * 60 + seconds;
double delay = (lenght / 120) * 2.5;
double raceTime = (lenght/100) * secondPer100Meters - delay;

//output
if (raceTime <= minimumTimeForOlympics)
{
    Console.WriteLine("Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {raceTime:F3}.");
}
else
{
    Console.WriteLine($"No, Marin failed! He was {(raceTime - minimumTimeForOlympics):F3} second slower.");
}
