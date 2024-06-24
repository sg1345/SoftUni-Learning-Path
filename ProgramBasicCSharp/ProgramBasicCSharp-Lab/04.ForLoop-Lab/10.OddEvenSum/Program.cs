
int countNumber = int.Parse(Console.ReadLine());

int resultEven = 0;
int resultOdd = 0;

for (int i = 1; i <= countNumber; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (i % 2 == 0)
    {
        resultEven += number;
    }
    else
    {
        resultOdd += number;
    }

}
int difference = Math.Abs(resultEven - resultOdd);

if (resultEven == resultOdd)
{
    Console.WriteLine($"Yes");
    Console.WriteLine($"Sum = {resultEven}");
}
else if (resultEven != resultOdd)
{
    Console.WriteLine($"No");
    Console.WriteLine($"Diff = {difference}");
}