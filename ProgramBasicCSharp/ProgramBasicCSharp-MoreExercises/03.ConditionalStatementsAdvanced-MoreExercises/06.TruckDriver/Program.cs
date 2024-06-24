
//input
string season = Console.ReadLine();
double distance = double.Parse(Console.ReadLine());

//calculation
double salary = 0;

if (season == "Spring" ||  season == "Autumn")
{
    if (distance <= 5000)
    {
        salary = (distance * 0.75 * 4) * 0.90;
    }
    else if (distance <= 10000)
    {
        salary = (distance * 0.95 * 4) * 0.90;

    }
    else if (distance <= 20000)
    {
        salary = (distance * 1.45 * 4) * 0.90;

    }
}
else if (season == "Summer")
{
    if (distance <= 5000)
    {
        salary = (distance * 0.90 * 4) * 0.90;
    }
    else if (distance <= 10000)
    {
        salary = (distance * 1.10 * 4) * 0.90;
    }
    else if (distance <= 20000)
    {
        salary = (distance * 1.45 * 4) * 0.90;
    }
}
else if (season == "Winter")
{
    if (distance <= 5000)
    {
        salary = (distance * 1.05 * 4) * 0.90;
    }
    else if (distance <= 10000)
    {
        salary = (distance * 1.25 * 4) * 0.90;
    }
    else if (distance <= 20000)
    {
        salary = (distance * 1.45 * 4) * 0.90;
    }
}

//output
Console.WriteLine($"{salary:f2}");