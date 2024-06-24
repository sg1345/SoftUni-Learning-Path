
using System.Runtime.ConstrainedExecution;

string product = Console.ReadLine();
string city = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());

double finalPrice = 0;

switch (city)
{
    case "Sofia":
        switch (product)
        {
            case "coffee":
                finalPrice = quantity * 0.5;
                break;
            case "water":
                finalPrice = quantity * 0.8;
                break;
            case "beer":
                finalPrice = quantity * 1.2;
                break;
            case "sweets":
                finalPrice = quantity * 1.45;
                break;
            case "peanuts":
                finalPrice = quantity * 1.6;
                break;

        }
        break;
    case "Plovdiv":
        switch (product)
        {
            case "coffee":
                finalPrice = quantity * 0.4;
                break;
            case "water":
                finalPrice = quantity * 0.7;
                break;
            case "beer":
                finalPrice = quantity * 1.15;
                break;
            case "sweets":
                finalPrice = quantity * 1.3;
                break;
            case "peanuts":
                finalPrice = quantity * 1.5;
                break;

        }
        break;
    case "Varna":
        switch (product)
        {
            case "coffee":
                finalPrice = quantity * 0.45;
                break;
            case "water":
                finalPrice = quantity * 0.7;
                break;
            case "beer":
                finalPrice = quantity * 1.1;
                break;
            case "sweets":
                finalPrice = quantity * 1.35;
                break;
            case "peanuts":
                finalPrice = quantity * 1.55;
                break;

        }
        break;
}
Console.WriteLine(finalPrice);