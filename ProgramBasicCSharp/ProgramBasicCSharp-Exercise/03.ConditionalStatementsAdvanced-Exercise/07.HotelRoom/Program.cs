
string month = Console.ReadLine();
int overnightStays = int.Parse(Console.ReadLine());

double finalPriceApartment = 0;
double finalPriceStudio = 0;

switch (month)
{
    case "May":
    case "October":
        if (overnightStays > 14)
        {
            finalPriceApartment = overnightStays * 65 * 0.90;
            finalPriceStudio = overnightStays * 50 * 0.70;
        }
        else if (overnightStays > 7)
        {
            finalPriceApartment = overnightStays * 65;
            finalPriceStudio = overnightStays * 50 * 0.95;
        }
        else
        {
            finalPriceApartment = overnightStays * 65;
            finalPriceStudio = overnightStays * 50;
        }
        break;
    case "June":
    case "September":
        if (overnightStays > 14)
        {
            finalPriceApartment = overnightStays * 68.70 * 0.90;
            finalPriceStudio = overnightStays * 75.20 * 0.80;
        }
        else
        {
            finalPriceApartment = overnightStays * 68.70;
            finalPriceStudio = overnightStays * 75.20;
        }
        break;
    case "July":
    case "August":
        if (overnightStays > 14)
        {
            finalPriceApartment = overnightStays * 77 * 0.90;
            finalPriceStudio = overnightStays * 76.00;
        }
        else
        {
            finalPriceApartment = overnightStays * 77.00;
            finalPriceStudio = overnightStays * 76.00;
        }
        break;
}
Console.WriteLine($"Apartment: {finalPriceApartment:f2} lv.");
Console.WriteLine($"Studio: {finalPriceStudio:f2} lv.");