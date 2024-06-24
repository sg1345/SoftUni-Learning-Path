
int countNumbers = int.Parse(Console.ReadLine());

int result = 0;

for (int i = 0; i < countNumbers; i++)
{
    int number= int.Parse(Console.ReadLine());

    result += number;
}
Console.WriteLine(result);