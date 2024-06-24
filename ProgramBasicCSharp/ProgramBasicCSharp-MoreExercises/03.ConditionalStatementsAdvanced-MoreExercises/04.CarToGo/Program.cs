
//input
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

//calculations
string autoClass = " ";
double rentPrice = 0;
string autoType = " ";

if (budget <= 100)
{
    autoClass = "Economy class";

    if (season == "Summer")
    {
        rentPrice = budget * 0.35;
        autoType = "Cabrio";
    }
    else if (season == "Winter")
    {
        rentPrice = budget *  0.65;
        autoType = "Jeep";
    }
}
else if (budget <= 500)
{
    autoClass = "Compact class";

    if (season == "Summer")
    {
        rentPrice = budget * 0.45;
        autoType = "Cabrio";
    }
    else if (season == "Winter")
    {
        rentPrice = budget * 0.80;
        autoType = "Jeep";
    }
}
else if (budget > 500)
{
    autoClass = "Luxury class";
    rentPrice = budget *  0.90;
    autoType = "Jeep";
}

Console.WriteLine(autoClass);
Console.WriteLine($"{autoType} - {rentPrice:f2}");