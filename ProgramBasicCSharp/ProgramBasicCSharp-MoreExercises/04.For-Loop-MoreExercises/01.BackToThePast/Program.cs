
double heritage = double.Parse(Console.ReadLine());
int yearToLiveInThePast = int.Parse(Console.ReadLine());

int ageOfIvan = 18;

for (int i = 1800; i <= yearToLiveInThePast; i++)
{

    if (i%2 == 0)
    {
        heritage -= 12000; 
    }
    else 
    {
        heritage -= (12000 + 50 * ageOfIvan);
    }
    ageOfIvan++;
}

if (heritage >= 0)
{
    Console.WriteLine($"Yes! He will live a carefree life and will have {heritage:f2} dollars left.");
}
else
{
    Console.WriteLine($"He will need {Math.Abs(heritage):f2} dollars to survive.");
}
