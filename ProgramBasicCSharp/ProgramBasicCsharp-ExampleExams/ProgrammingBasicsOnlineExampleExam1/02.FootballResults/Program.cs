/*
char foo = char.Parse(Console.ReadLine());
//int num = foo-'0';
int num = int.Parse(Convert.ToString(foo));
Console.WriteLine(num);
*/
//Input
string result1 = Console.ReadLine();
string result2 = Console.ReadLine();
string result3 = Console.ReadLine();

//calculcations
char[] scoreFromResult1 = result1.ToCharArray();
char[] scoreFromResult2 = result2.ToCharArray();
char[] scoreFromResult3 = result3.ToCharArray();


int goalsScoredGame1 = int.Parse(Convert.ToString(scoreFromResult1[0]));
int goalsRecievedGame1 = int.Parse(Convert.ToString(scoreFromResult1[2]));

int goalsScoredGame2 = int.Parse(Convert.ToString(scoreFromResult2[0]));
int goalsRecievedGame2 = int.Parse(Convert.ToString(scoreFromResult2[2]));

int goalsScoredGame3 = int.Parse(Convert.ToString(scoreFromResult3[0]));
int goalsRecievedGame3 = int.Parse(Convert.ToString(scoreFromResult3[2]));

int wonGames = 0;
int lostGames =0;
int drawnGames =0;

if (goalsScoredGame1 > goalsRecievedGame1)
{
    wonGames++;
}
else if (goalsScoredGame1 < goalsRecievedGame1)
{
    lostGames++;
}
else
{
    drawnGames++;
}
if (goalsScoredGame2 > goalsRecievedGame2)
{
    wonGames++;
}
else if (goalsScoredGame2 < goalsRecievedGame2)
{
    lostGames++;
}
else
{
    drawnGames++;
}
if (goalsScoredGame3 > goalsRecievedGame3)
{
    wonGames++;
}
else if (goalsScoredGame3 < goalsRecievedGame3)
{
    lostGames++;
}
else
{
    drawnGames++;
}

//output
Console.WriteLine($"Team won {wonGames} games.");
Console.WriteLine($"Team lost {lostGames} games.");
Console.WriteLine($"Drawn games: {drawnGames}");