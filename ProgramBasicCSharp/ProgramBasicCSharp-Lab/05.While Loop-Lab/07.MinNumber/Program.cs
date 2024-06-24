
string input = Console.ReadLine();

int minValue = int.MaxValue;

while (input != "Stop")
{
    if (minValue > int.Parse(input))
    {
        minValue = int.Parse(input);
    }

    input = Console.ReadLine();
}
Console.WriteLine(minValue);