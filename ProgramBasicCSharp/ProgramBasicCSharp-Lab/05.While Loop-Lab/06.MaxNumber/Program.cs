
string input = Console.ReadLine(); 

int maxValue = int.MinValue;

while (input != "Stop")
{
    if (maxValue < int.Parse(input))
    {
        maxValue = int.Parse(input);
    }

 input = Console.ReadLine();
}
Console.WriteLine(maxValue);