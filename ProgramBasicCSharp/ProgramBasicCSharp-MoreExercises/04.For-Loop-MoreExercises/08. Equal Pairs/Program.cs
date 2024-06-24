
int pairs = int.Parse(Console.ReadLine());


int sum = 0;
int previousSum = 0;

int maxDiff = 0;

for (int i = 0; i < pairs; i++)
{
    int number1 = int.Parse(Console.ReadLine());
    int number2 = int.Parse(Console.ReadLine());

    sum = number1 + number2;

    if (i > 0)
    {
        int difference = Math.Abs(sum - previousSum);

        if (maxDiff != difference)
        {
            maxDiff = difference;
        }
    }

    previousSum = sum;

}

if (maxDiff == 0)
{
    Console.WriteLine($"Yes, value={sum}");
}
else 
{
    Console.WriteLine($"No, maxdiff={maxDiff}");
}