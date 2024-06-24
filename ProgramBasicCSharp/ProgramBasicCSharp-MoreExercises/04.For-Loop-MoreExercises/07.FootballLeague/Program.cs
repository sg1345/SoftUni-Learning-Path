
int capacity = int.Parse(Console.ReadLine());
int countFans  = int.Parse(Console.ReadLine());

int countA = 0;
int countB = 0;
int countV = 0;
int countG = 0;

for (int i = 0; i < countFans; i++)
{
    string sector = Console.ReadLine();

    switch (sector)
    {
        case "A":
            countA++;
            break;
        case "B":
            countB++;
            break;
        case "V":
            countV++;
            break;
        case "G":
            countG++;
            break;
    }
}

Console.WriteLine($"{100.00 * countA / (countA + countB + countV + countG):F2}%");
Console.WriteLine($"{100.00 * countB / (countA + countB + countV + countG):F2}%");
Console.WriteLine($"{100.00 * countV / (countA + countB + countV + countG):F2}%");
Console.WriteLine($"{100.00 * countG / (countA + countB + countV + countG):F2}%");
Console.WriteLine($"{100.00 * countFans / capacity:F2}%");
