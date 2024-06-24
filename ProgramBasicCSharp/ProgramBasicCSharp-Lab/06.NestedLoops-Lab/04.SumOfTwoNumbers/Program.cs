
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
int magicNumber = int.Parse(Console.ReadLine());

int count = 0;
bool isTrue = false;

for (int i = number1; i <= number2; i++)
{
    if(isTrue)
    { break; }
    for (int j = number1; j <= number2; j++)
    {
        count++;

        if (i+j == magicNumber)
        {
            isTrue = true;
            Console.WriteLine($"Combination N:{count} ({i} + {j} = {magicNumber})");
            break;
        }
    }
}
if (!isTrue)
{
    Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
}