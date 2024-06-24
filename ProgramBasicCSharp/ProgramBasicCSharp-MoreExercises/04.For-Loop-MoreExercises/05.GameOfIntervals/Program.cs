
int moves = int.Parse(Console.ReadLine());

int countInvalidNumber = 0;
int countFrom0To9 = 0;
int countFrom10To19 = 0;
int countFrom20To29 = 0;
int countFrom30To39 = 0;
int countFrom40To50 = 0;

double result = 0;

for (int i = 0; i < moves; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (number < 0 || number > 50)
    {
      countInvalidNumber++;
        result /= 2;
    }
    else if (number < 10)
    {
        countFrom0To9++;
        result += (number * 0.2);
    }
    else if (number < 20)
    {
        countFrom10To19++;
        result += (number * 0.3);
    }
    else if (number < 30)
    {
        countFrom20To29++;
        result += (number * 0.4);
    }
    else if (number < 40)
    {
        countFrom30To39++;
        result += 50;
    }
    else if (number <= 50)
    {
        countFrom40To50++;
        result += 100;
    }
}

Console.WriteLine($"{result:f2}");
Console.WriteLine($"From 0 to 9: {100.00 * countFrom0To9 / (countFrom0To9 + countFrom10To19 + countFrom20To29 + countFrom30To39 + countFrom40To50 + countInvalidNumber):f2}%");
Console.WriteLine($"From 10 to 19: {100.00 * countFrom10To19 / (countFrom0To9 + countFrom10To19 + countFrom20To29 + countFrom30To39 + countFrom40To50 + countInvalidNumber):f2}%");
Console.WriteLine($"From 20 to 29: {100.00 * countFrom20To29 / (countFrom0To9 + countFrom10To19 + countFrom20To29 + countFrom30To39 + countFrom40To50 + countInvalidNumber):f2}%");
Console.WriteLine($"From 30 to 39: {100.00 * countFrom30To39 / (countFrom0To9 + countFrom10To19 + countFrom20To29 + countFrom30To39 + countFrom40To50 + countInvalidNumber):f2}%");
Console.WriteLine($"From 40 to 50: {100.00 * countFrom40To50 / (countFrom0To9 + countFrom10To19 + countFrom20To29 + countFrom30To39 + countFrom40To50 + countInvalidNumber):f2}%");
Console.WriteLine($"Invalid numbers: {100.00 * countInvalidNumber / (countFrom0To9 + countFrom10To19 + countFrom20To29 + countFrom30To39 + countFrom40To50 + countInvalidNumber):f2}%");
