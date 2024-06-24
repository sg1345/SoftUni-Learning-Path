
int countNumbers = int.Parse(Console.ReadLine());

double maxValueOdd = double.MinValue;
double minValueOdd = double.MaxValue;

double maxValueEven = double.MinValue;
double minValueEven = double.MaxValue;

double sumOdd = 0;
double sumEven = 0;

for (int i = 1; i <= countNumbers; i++)
{
    double number = double.Parse(Console.ReadLine());
    
    if (i % 2 == 0)
    {
        sumEven += number;
        if (number > maxValueEven)
        {
            maxValueEven = number;
        }
        if (number < minValueEven)
        {
            minValueEven = number;
        }
    }
    else
    {
        sumOdd += number;

        if (number > maxValueOdd)
        {
            maxValueOdd = number;
        }
        if (number < minValueOdd)
        {
            minValueOdd = number;
        }
    }
}

Console.WriteLine($"OddSum={sumOdd:f2},");

if (maxValueOdd == double.MinValue) 
{
    Console.WriteLine("OddMin=No,");
    Console.WriteLine("OddMax=No,");
}
else
{
    Console.WriteLine($"OddMin={minValueOdd:f2},");
    Console.WriteLine($"OddMax={maxValueOdd:f2},");
}

Console.WriteLine($"EvenSum={sumEven:f2},");

if (maxValueEven == double.MinValue)
{
    Console.WriteLine("EvenMin=No,");
    Console.WriteLine("EvenMax=No");
}
else
{
    Console.WriteLine($"EvenMin={minValueEven:f2},");
    Console.WriteLine($"EvenMax={maxValueEven:f2}");
}