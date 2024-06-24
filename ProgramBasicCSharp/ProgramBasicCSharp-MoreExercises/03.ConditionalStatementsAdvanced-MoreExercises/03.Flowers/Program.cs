
//Сезон           Хризантеми            Рози                Лалета
//Пролет / Лято   2.00 лв./бр.     4.10 лв./бр.            2.50 лв./бр.
//Есен / Зима     3.75 лв./бр.     4.50 лв./бр.            4.15 лв./бр.

//input
int countChrysanthemums = int.Parse(Console.ReadLine());
int countRoses = int.Parse(Console.ReadLine());
int countTulips = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
string hollyday = Console.ReadLine();

//calculations
double flowersPrice = 0;

if (season == "Spring" || season == "Summer")
{
    flowersPrice = countChrysanthemums * 2.00 + countRoses * 4.10 + countTulips * 2.50;
}
else if (season == "Autumn" || season == "Winter")
{
    flowersPrice = countChrysanthemums * 3.75 + countRoses * 4.50 + countTulips * 4.15;
}

if (hollyday == "Y")
{
    flowersPrice *= 1.15;
}

if (countTulips > 7 && season == "Spring")
{
    flowersPrice *= 0.95;
}

if (countRoses >= 10 && season == "Winter")
{
    flowersPrice *= 0.90;
}

if (countChrysanthemums + countRoses + countTulips > 20)
{
    flowersPrice *= 0.80;
}

flowersPrice += 2.00; //аранжимент

//output
Console.WriteLine($"{flowersPrice:f2}");