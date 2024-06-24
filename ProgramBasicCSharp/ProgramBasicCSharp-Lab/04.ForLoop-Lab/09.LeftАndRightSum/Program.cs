
int countNumber = int.Parse(Console.ReadLine());

int resultLeft = 0;
int resultRight = 0;

for (int i = 1; i <= countNumber*2; i++)
{
    int number1 = int.Parse(Console.ReadLine());
    if( i <= countNumber)
    {
        resultLeft += number1;
    }
    else
    {
        resultRight += number1;
    }
}

int difference =Math.Abs(resultLeft - resultRight);

if (resultLeft == resultRight)
{
    Console.WriteLine($"Yes, sum = {resultLeft}");
}
else if (resultLeft != resultRight)
{
    Console.WriteLine($"No, diff = {difference}");
}