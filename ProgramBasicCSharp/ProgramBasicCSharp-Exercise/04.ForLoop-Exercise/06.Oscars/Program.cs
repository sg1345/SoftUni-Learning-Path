
string nameCandidate = Console.ReadLine();
double akademiePoints = double.Parse(Console.ReadLine());
int countJuries = int.Parse(Console.ReadLine());

bool isValid = false;

for (int i = 0; i < countJuries; i++)
{
    string nameJury = Console.ReadLine();
    double pointsJury = double.Parse(Console.ReadLine());

    akademiePoints += ((pointsJury * nameJury.Length)/2);

    if (akademiePoints >= 1250.5)
    {
        isValid = true;
        Console.WriteLine($"Congratulations, {nameCandidate} got a nominee for leading role with {akademiePoints:f1}!");
        break;
    }

}
if (!isValid)
{
    double difference = Math.Abs( 1250.5 - akademiePoints);
    Console.WriteLine($"Sorry, {nameCandidate} you need {difference:f1} more!");
}