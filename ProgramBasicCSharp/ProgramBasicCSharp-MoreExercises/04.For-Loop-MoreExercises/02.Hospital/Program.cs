
int pediod = int.Parse(Console.ReadLine());

int doctors = 7;
int treatedPatients = 0;
int untreatedPatients = 0;

for (int i = 1; i <= pediod; i++)
{
    int countPatients = int.Parse(Console.ReadLine());

    if (treatedPatients < untreatedPatients && i%3 == 0)
    {
        doctors++;
    }

    if (countPatients == doctors)
    {
        treatedPatients += doctors;
        //untreatedPatients += 0;
    }
    else if (countPatients > doctors)
    {
        treatedPatients += doctors;
        untreatedPatients += (countPatients - doctors);
    }
    else if (countPatients < doctors)
    {
        treatedPatients += countPatients;
        //untreatedPatients += 0;
    }


}

Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {untreatedPatients}.");