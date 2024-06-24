
double sum = 0;
double number = 0;

while (true)
{
    string command = Console.ReadLine();
    
    if (command == "NoMoreMoney")
    {
        Console.WriteLine($"Total: {sum:f2}");
        break;
    }
    number = double.Parse(command);
    if (number <= 0)
    {
        Console.WriteLine("Invalid operation!");
        Console.WriteLine($"Total: {sum:f2}");
        break;
    }
    
    sum += number;
    
    Console.WriteLine($"Increase: {number:f2}");
}