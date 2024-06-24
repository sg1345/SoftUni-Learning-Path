
//input
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();  //Summer or Winter

//calculations
string sleepPlaceClass = " "; //Hotel, Hut, Camp
double price = 0;
string place = " "; //Alaska ir Morroco

if (budget <= 1000)
{
    sleepPlaceClass = "Camp";

    if (season == "Summer")
    {
        price = budget * 0.65;
        place = "Alaska";
    }
    else if (season == "Winter")
    {
        price = budget * 0.45;
        place = "Morocco";
    }
}
else if (budget <= 3000)
{
    sleepPlaceClass = "Hut";

    if (season == "Summer")
    {
        price = budget * 0.80;
        place = "Alaska";
    }
    else if (season == "Winter")
    {
        price = budget * 0.60;
        place = "Morocco";
    }
}
else if (budget > 3000)
{
    sleepPlaceClass = "Hotel";

    if (season == "Summer")
    {
        price = budget * 0.90;
        place = "Alaska";
    }
    else if (season == "Winter")
    {
        price = budget * 0.90;
        place = "Morocco";
    }
}

//output
Console.WriteLine($"{place} - {sleepPlaceClass} - {price:f2}");