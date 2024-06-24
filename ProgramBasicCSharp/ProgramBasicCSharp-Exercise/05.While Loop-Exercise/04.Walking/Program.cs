
int overallSteps = 0;


while (overallSteps < 10000)
{
    string input = Console.ReadLine();

    if (input == "Going home")
    {
        input = Console.ReadLine();

        overallSteps += int.Parse(input);
        break;
    }

    overallSteps += int.Parse(input);
}

int difference = Math.Abs(overallSteps-10000);

if (overallSteps >= 10000)
{
    Console.WriteLine("Goal reached! Good job!");
    Console.WriteLine($"{difference} steps over the goal!");
}
else
{
    Console.WriteLine($"{difference} more steps to reach goal.");
}