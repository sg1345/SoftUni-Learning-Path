
//Група       trail         crosscountry         downhill        road
//juniors     5.50                8               12.25           20
//seniors      7                 9.50             13.75          21.50

//input
int juniorBikers = int.Parse(Console.ReadLine());
int seniorBikers  = int.Parse(Console.ReadLine());
string traceType  = Console.ReadLine();

//calculations
double budget = 0;

switch (traceType)
{
    case "trail":
        budget = juniorBikers * 5.50 + seniorBikers * 7.00;
        break;

    case "cross-country":
        budget = juniorBikers * 8.00 + seniorBikers * 9.50;
        break;

    case "downhill":
        budget = juniorBikers * 12.25 + seniorBikers * 13.75;
        break;

    case "road":
        budget = juniorBikers * 20.00 + seniorBikers * 21.50;
        break;
}

if (traceType == "cross-country" && juniorBikers + seniorBikers >= 50)
{
    budget *= 0.75;
}

double donation = budget * 0.95;

//output
Console.WriteLine($"{donation:f2}");