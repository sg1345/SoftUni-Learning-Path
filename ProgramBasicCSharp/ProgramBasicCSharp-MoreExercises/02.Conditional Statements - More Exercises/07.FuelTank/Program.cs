
//input
string fuelType = Console.ReadLine();
int fuelLiters = int.Parse(Console.ReadLine());

//proccessing
string fuelName;

if (fuelType == "Diesel")
{
    fuelName = "diesel";
}
else if (fuelType == "Gasoline")
{
    fuelName = "gasoline";
}
else
{
    fuelName = "gas";
}

//output
if (fuelType =="Diesel" || fuelType == "Gasoline" || fuelType == "Gas")
{

    if (fuelLiters >= 25)
    {
        Console.WriteLine($"You have enough {fuelName}.");
    }
    else
    {
        Console.WriteLine($"Fill your tank with {fuelName}!");
    }
}
else
{
    Console.WriteLine("Invalid fuel!");
}