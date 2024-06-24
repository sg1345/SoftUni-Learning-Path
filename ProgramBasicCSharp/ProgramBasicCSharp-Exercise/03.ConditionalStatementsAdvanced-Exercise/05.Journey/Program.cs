
double budget = double.Parse(Console.ReadLine());
string season  = Console.ReadLine();

string typeHoliday = "";
string destination = "";
double moneySpend = 0;

if (budget <= 100)
{
    destination = "Bulgaria";

    switch (season)
    {
        case "summer":
            typeHoliday = "Camp";
            moneySpend = budget * 0.30;
            break;
        case "winter":
            typeHoliday = "Hotel";
            moneySpend = budget * 0.70;
            break;
    }
}
else if (budget <= 1000)
{
    destination = "Balkans";

    switch (season)
    {
        case "summer":
            typeHoliday = "Camp";
            moneySpend = budget * 0.40;
            break;
        case "winter":
            typeHoliday = "Hotel";
            moneySpend = budget * 0.80;
            break;
    }
}
else if (budget >= 1000)
{
    destination = "Europe";
    typeHoliday = "Hotel";
    moneySpend = budget * 0.90;
}

Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{typeHoliday} - {moneySpend:f2}");