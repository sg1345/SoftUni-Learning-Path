
int countTournaments = int.Parse(Console.ReadLine());
int points  = int.Parse(Console.ReadLine());

double averagePoints = 0;
int wins = 0;

for (int i = 0; i < countTournaments; i++)
{
    string positionInTournament = Console.ReadLine();

    switch(positionInTournament)
    {
        case "W":
            points += 2000;
            averagePoints += 2000;
            wins++;
            break;
        case "F":
            points += 1200;
            averagePoints += 1200;
            break;
        case "SF":
            points += 720;
            averagePoints += 720;
            break;
    }
}
averagePoints /= (double)countTournaments;


Console.WriteLine($"Final points: {points}");
Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
Console.WriteLine($"{(double)wins/countTournaments*100:f2}%");

