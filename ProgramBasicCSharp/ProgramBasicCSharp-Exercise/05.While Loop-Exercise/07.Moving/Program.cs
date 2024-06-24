
int width = int.Parse(Console.ReadLine());
int lenght = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());

int space = width * height * lenght;

while (space > 0)
{
    string input = Console.ReadLine();

    if (input == "Done")
    {
        Console.WriteLine($"{space} Cubic meters left.");
        break;
    }
    space -=int.Parse(input);

}

if (space < 0)
{
    space = Math.Abs(space);
    Console.WriteLine($"No more free space! You need {space} Cubic meters more.");
}