//input
int nKilometers = int.Parse(Console.ReadLine());
string DayOrNight = Console.ReadLine();

//calculations
double priceTaxiDayTime = nKilometers * 0.79 + 0.70;
double priceTaxiNightTime = nKilometers * 0.90 + 0.70;

double priceBus = nKilometers * 0.09;
double priceTrain = nKilometers * 0.06;

//output
if (nKilometers >= 100)
{
    Console.WriteLine($"{priceTrain:F2}");
}
else if (nKilometers >= 20)
{
    Console.WriteLine($"{priceBus:F2}");

}
else if ( DayOrNight == "day")
{
    Console.WriteLine($"{priceTaxiDayTime:F2}");

}
else
{
    Console.WriteLine($"{priceTaxiNightTime:F2}");

}
