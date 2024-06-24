//input
int startingPoints = int.Parse(Console.ReadLine());

double bonusPoints = 0;



//calculations

if (startingPoints <= 100 )
{
    bonusPoints += 5;
}
else if (startingPoints >= 1000)
{
    bonusPoints = startingPoints * 0.1;
}
else
{
    bonusPoints = startingPoints * 0.2;
}

if (startingPoints % 2 == 0)
{
    bonusPoints++;
}
if (startingPoints % 10 == 5)
{
    bonusPoints += 2;
}

double finalPoints = startingPoints + bonusPoints;

//output
Console.WriteLine(bonusPoints);
Console.WriteLine(finalPoints);