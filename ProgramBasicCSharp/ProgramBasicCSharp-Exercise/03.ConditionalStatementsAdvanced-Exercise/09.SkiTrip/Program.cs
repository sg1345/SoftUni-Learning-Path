
// "room for one person" – 18.00 лв за нощувка
// "apartment" – 25.00 лв за нощувка
// "president apartment" – 35.00 лв за нощувка

int holiday = int.Parse(Console.ReadLine());
string typeOfRoom = Console.ReadLine();
string rating = Console.ReadLine();

int nights = holiday - 1;
double finalPrice = 0;

switch (typeOfRoom)
{
    case "room for one person":
        if (rating == "positive")
        {
            finalPrice = nights * 18.00 * 1.25; 
        }
        else if(rating == "negative")
        {
            finalPrice = nights * 18.00 * 0.90;
        }

        break;
    case "apartment":
        if (holiday < 10)
        {
            if (rating == "positive")
            {
                finalPrice = (nights * 25.00 * 0.70) * 1.25;
            }
            else if (rating == "negative")
            {
                finalPrice = (nights * 25.00 * 0.70) * 0.90;
            }
        }
        else if (holiday >= 10 && holiday <= 15)
        {
            if (rating == "positive")
            {
                finalPrice = (nights * 25.00 * 0.65) * 1.25;
            }
            else if (rating == "negative")
            {
                finalPrice = (nights * 25.00 * 0.65) * 0.90;
            }
        }
        else if (holiday > 15)
        {
            if (rating == "positive")
            {
                finalPrice = (nights * 25.00 * 0.50) * 1.25;
            }
            else if (rating == "negative")
            {
                finalPrice = (nights * 25.00 * 0.50) * 0.90;
            }
        }
        break;
    case "president apartment":
        if (holiday < 10)
        {
            if (rating == "positive")
            {
                finalPrice = (nights * 25.00 * 0.90) * 1.25;
            }
            else if (rating == "negative")
            {
                finalPrice = (nights * 25.00 * 0.90) * 0.90;
            }
        }
        else if (holiday >= 10 && holiday <= 15)
        {
            if (rating == "positive")
            {
                finalPrice = (nights * 25.00 * 0.85) * 1.25;
            }
            else if (rating == "negative")
            {
                finalPrice = (nights * 25.00 * 0.85) * 0.90;
            }
        }
        else if (holiday > 15)
        {
            if (rating == "positive")
            {
                finalPrice = (nights * 35.00 * 0.80) * 1.25;
            }
            else if (rating == "negative")
            {
                finalPrice = (nights * 35.00 * 0.80) * 0.90;
            }
        }
        break;
}
Console.WriteLine($"{finalPrice:f2}");