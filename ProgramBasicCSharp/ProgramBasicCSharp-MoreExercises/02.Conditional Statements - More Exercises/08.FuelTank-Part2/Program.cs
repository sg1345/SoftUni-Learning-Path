/* Бензин - 2.22лв/л.
 * Дизел - 2.33лв/л.
 * Газ - 0.93лв/л.
 
 * Клубна карта :
 * 18ст/л. за бензин
 * 12ст/л. за дизел
 * 8ст/л. за газ
 
 *Отсъпка:
 *20-25л. - 8%
 *над 25л - 10%
 */
//input
string fuelType = Console.ReadLine();
double fuelAmount = double.Parse(Console.ReadLine());
string clubCard = Console.ReadLine();

//calculations
double finalPrice; 

if (fuelType == "Gasoline")
{
    if (clubCard == "Yes")
    {
        if (fuelAmount > 25)
        {
            finalPrice = fuelAmount * (2.22 - 0.18) * 0.90;
        }
        else if (fuelAmount >=20)
        {
        finalPrice = fuelAmount * (2.22 - 0.18) * 0.92;
        }
        else
        {
        finalPrice = fuelAmount * (2.22 - 0.18);
        }
    }
    else
    {
        if (fuelAmount > 25)
        {
            finalPrice = fuelAmount * 2.22 * 0.90;
        }
        else if (fuelAmount >= 20)
        {
            finalPrice = fuelAmount * 2.22  * 0.92;
        }
        else
        {
            finalPrice = fuelAmount * 2.22;
        }
    }
}
else if (fuelType == "Diesel")
{
    if (clubCard == "Yes")
    {
        if (fuelAmount > 25)
        {
            finalPrice = fuelAmount * (2.33 - 0.12) * 0.90;
        }
        else if (fuelAmount >= 20)
        {
            finalPrice = fuelAmount * (2.33 - 0.12) * 0.92;
        }
        else
        {
            finalPrice = fuelAmount * (2.33 - 0.12);
        }
    }
    else
    {
        if (fuelAmount > 25)
        {
            finalPrice = fuelAmount * 2.33 * 0.90;
        }
        else if (fuelAmount >= 20)
        {
            finalPrice = fuelAmount * 2.33 * 0.92;
        }
        else
        {
            finalPrice = fuelAmount * 2.33;
        }
    }
}
else
{
    if (clubCard == "Yes")
    {
        if (fuelAmount > 25)
        {
            finalPrice = fuelAmount * (0.93 - 0.08) * 0.90;
        }
        else if (fuelAmount >= 20)
        {
            finalPrice = fuelAmount * (0.93 - 0.08) * 0.92;
        }
        else
        {
            finalPrice = fuelAmount * (0.93 - 0.08);
        }
    }
    else
    {
        if (fuelAmount > 25)
        {
            finalPrice = fuelAmount * 0.93 * 0.90;
        }
        else if (fuelAmount >= 20)
        {
            finalPrice = fuelAmount * 0.93 * 0.92;
        }
        else
        {
            finalPrice = fuelAmount * 0.93;
        }
    }
}

//output
Console.WriteLine($"{finalPrice:F2} lv.");