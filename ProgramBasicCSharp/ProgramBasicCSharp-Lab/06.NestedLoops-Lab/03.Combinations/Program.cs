
int number = int.Parse(Console.ReadLine());

int count = 0;
int sum = 0;

for  (int i = 0; i <= number; i++)
{
    for (int j = 0; j <= number; j++)
    {
        for (int k = 0; k <= number; k++)
        {
            sum = i + j + k;
           if (sum == number)
            count++;
        }
    }
}
Console.WriteLine(count);