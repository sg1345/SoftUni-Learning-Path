
int detergent = int.Parse(Console.ReadLine());
int count = 0;

detergent *= 750;
int dishes = 0;
int pots = 0;

while (true)
{
    string input = Console.ReadLine();
    count++;

    if (input == "End")
    {
        break;
    }

    if (count % 3 == 0)
    {
        pots += int.Parse(input);
        detergent -= 15 * int.Parse(input);
    }
    else
    {
        dishes += int.Parse(input);
        detergent -= 5 * int.Parse(input);
    }


    if (detergent < 0)
    {
        break;
    }
}

if (detergent >= 0)
{
    Console.WriteLine("Detergent was enough!");
    Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
    Console.WriteLine($"Leftover detergent {detergent} ml.");
}
else
{
    Console.WriteLine($"Not enough detergent, {Math.Abs(detergent)} ml. more necessary!");
}

    