
int width = int.Parse(Console.ReadLine());
int lenght  = int.Parse(Console.ReadLine());

int piecesCake = width * lenght;

while (piecesCake > 0)
{
    string piecesTaken = Console.ReadLine();

    if (piecesTaken == "STOP")
    {
        Console.WriteLine($"{piecesCake} pieces are left.");
        break;
    }

    piecesCake -= int.Parse(piecesTaken);
}

if (piecesCake <= 0)
{
    piecesCake = Math.Abs(piecesCake);
    Console.WriteLine($"No more cake left! You need {piecesCake} pieces more.");
}