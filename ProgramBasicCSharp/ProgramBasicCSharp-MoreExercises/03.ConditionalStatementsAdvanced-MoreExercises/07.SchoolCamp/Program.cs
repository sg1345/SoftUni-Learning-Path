
//input
using System.Diagnostics.Tracing;

string season = Console.ReadLine();
string typeGroup  = Console.ReadLine();
int countStudents = int.Parse(Console.ReadLine());
int nightsSpend  = int.Parse(Console.ReadLine());

//calculation
string activities = " ";
double price = 0;
double discount = 0;

if (countStudents >= 10 && countStudents < 20)
{
    discount = 0.95;
}
else if (countStudents >= 20 && countStudents < 50)
{
    discount = 0.85;
}
else if (countStudents >= 50)
{
    discount = 0.50;
}
else
{
    discount = 1.00;
}

if (season == "Winter")
{
    if (typeGroup == "boys")
    {
        activities = "Judo";

        price = (nightsSpend * 9.60 * countStudents) * discount;

    }
    else if(typeGroup == "girls")
    {
        activities = "Gymnastics";

        price = (nightsSpend * 9.60 * countStudents) * discount;

    }
    else if (typeGroup == "mixed")
    {
        activities = "Ski";

        price = (nightsSpend * 10.00 * countStudents) * discount;

    }
}
else if (season == "Spring")
{
    if (typeGroup == "boys")
    {
        activities = "Tennis";

        price = (nightsSpend * 7.20 * countStudents) * discount;
    }
    else if (typeGroup == "girls")
    {
        activities = "Athletics";

        price = (nightsSpend * 7.20 * countStudents) * discount;
    }
    else if (typeGroup == "mixed")
    {
        activities = "Cycling";

        price = (nightsSpend * 9.50 * countStudents) * discount;
    }
}
else if (season == "Summer")
{
    if (typeGroup == "boys")
    {
        activities = "Football";

        price = (nightsSpend * 15.00 * countStudents) * discount;
    }
    else if (typeGroup == "girls")
    {
        activities = "Volleyball";

        price = (nightsSpend * 15.00 * countStudents) * discount;
    }
    else if (typeGroup == "mixed")
    {
        activities = "Swimming";

        price = (nightsSpend * 20.00 * countStudents) * discount;
    }
}

//output
Console.WriteLine($"{activities} {price:f2} lv.");