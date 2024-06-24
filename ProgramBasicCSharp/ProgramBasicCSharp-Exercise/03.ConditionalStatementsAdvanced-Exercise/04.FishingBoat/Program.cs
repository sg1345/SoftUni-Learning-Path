
int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int countFishermen = int.Parse(Console.ReadLine());

double finalPrice = 0;

switch (season)
{
    case "Spring": //3000
        if (countFishermen%2 == 0) //5%
        {
            if (countFishermen <= 6)
            {
                finalPrice = 3000 * 0.90 * 0.95; 
            }
            else if (countFishermen >=7 && countFishermen <= 11)
            {
                finalPrice = 3000 * 0.85 *0.95;
            }
            else if(countFishermen >12)
            {
                finalPrice = 3000 * 0.75 * 0.95;
            }
        }
        else
        {
            if (countFishermen <= 6)
            {
                finalPrice = 3000 * 0.90;
            }
            else if (countFishermen >= 7 && countFishermen <= 11)
            {
                finalPrice = 3000 * 0.85;
            }
            else if (countFishermen > 12)
            {
                finalPrice = 3000 * 0.75;

            }
        }
        break;
    case "Summer": //4200
        if (countFishermen % 2 == 0) //5%
        {
            if (countFishermen <= 6)
            {
                finalPrice = 4200 * 0.90 * 0.95;

            }
            else if (countFishermen >= 7 && countFishermen <= 11)
            {
                finalPrice = 4200 * 0.85 *0.95;

            }
            else if (countFishermen > 12)
            {
                finalPrice = 4200 * 0.75 * 0.95;

            }
        }
        else
        {
            if (countFishermen <= 6)
            {
                finalPrice = 4200 * 0.90;
            }
            else if (countFishermen >= 7 && countFishermen <= 11)
            {
                finalPrice = 4200 * 0.85;
            }
            else if (countFishermen > 12)
            {
                finalPrice = 4200 * 0.75;

            }
        }
        break;
    case "Autumn": //4200
        if (countFishermen <= 6)
        {
            finalPrice = 4200 * 0.90;
        }
        else if (countFishermen >= 7 && countFishermen <= 11)
        {
            finalPrice = 4200 * 0.85;
        }
        else if (countFishermen > 12)
        {
            finalPrice = 4200 * 0.75;
        }
        break;
    case "Winter": //2600
        if (countFishermen % 2 == 0) //5%
        {
            if (countFishermen <= 6)
            {
                finalPrice = 2600 * 0.90 * 0.95;
            }
            else if (countFishermen >= 7 && countFishermen <= 11)
            {
                finalPrice = 2600 * 0.85 * 0.95;
            }
            else if (countFishermen > 12)
            {
                finalPrice = 2600 * 0.75 * 0.95;
            }
        }
        else
        {
            if (countFishermen <= 6)
            {
                finalPrice = 2600 * 0.90;

            }
            else if (countFishermen >= 7 && countFishermen <= 11)
            {
                finalPrice = 2600 * 0.85;
            }
            else if (countFishermen > 12)
            {
                finalPrice = 2600 * 0.75;
            }
        }
        break;
}

double difference = Math.Abs(finalPrice - budget);

if (finalPrice > budget)
{
    Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
}
else if (finalPrice <= budget)
{
    Console.WriteLine($"Yes! You have {difference:f2} leva left.");
}