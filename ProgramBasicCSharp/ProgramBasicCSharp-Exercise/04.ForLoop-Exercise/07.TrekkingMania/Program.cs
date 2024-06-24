
int countGroups = int.Parse(Console.ReadLine());

int overallPeople = 0;

int musala = 0, monblan = 0, kilimanjaro = 0, k2 = 0, everest = 0;

for (int i = 0; i < countGroups; i++)
{
    int countPeoplePerGroup = int.Parse(Console.ReadLine());

    overallPeople += countPeoplePerGroup;

    if(countPeoplePerGroup <= 5)
    {
        musala += countPeoplePerGroup;
    }
    else if(countPeoplePerGroup <= 12)
    {
        monblan += countPeoplePerGroup;
    }
    else if (countPeoplePerGroup <= 25)
    {
        kilimanjaro += countPeoplePerGroup;
    }
    else if (countPeoplePerGroup <= 40)
    {
        k2 += countPeoplePerGroup;
    }
    else { everest += countPeoplePerGroup; }
}

Console.WriteLine($"{(double)musala/overallPeople*100:f2}%");
Console.WriteLine($"{(double)monblan/overallPeople*100:f2}%");
Console.WriteLine($"{(double)kilimanjaro/overallPeople*100:f2}%");
Console.WriteLine($"{(double)k2/overallPeople*100:f2}%");
Console.WriteLine($"{(double)everest/overallPeople*100:f2}%");