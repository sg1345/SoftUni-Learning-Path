
int number = int.Parse(Console.ReadLine());

int counter = 0;
int sum = 1;

while (true)
{
    sum = 2 * counter + 1;
    counter = sum;
    if (sum > number)
    {
        break;
    }
    Console.WriteLine(sum);
}
