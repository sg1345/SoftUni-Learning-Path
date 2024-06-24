
int countNumber = int.Parse(Console.ReadLine());

int maxValue = int.MinValue;
int result = 0;

for (int i = 0; i < countNumber; i++)
{
    int number = int.Parse(Console.ReadLine());

    if(number > maxValue)
    {
        maxValue = number;
    }
    result += number;
}

result -=maxValue;


if(result == maxValue)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {result}");
}
else if(result != maxValue)
{
int difference = Math.Abs(result-maxValue);

    Console.WriteLine("No");
    Console.WriteLine($"Diff = {difference}");
}