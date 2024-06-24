//input
int hours = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());

//calculations
int outputMinutes = minutes + 15;
int outputHours = hours + outputMinutes / 60;

if (outputMinutes >=60)
{
    outputMinutes = outputMinutes % 60;
}
if (outputHours == 24)
{
    outputHours = 0;
}

//output
Console.WriteLine($"{outputHours}:{outputMinutes:D2}");