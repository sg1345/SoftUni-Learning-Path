
 string name = Console.ReadLine();

int countYear = 0;
int countFails = 0;

double sumGrade = 0;

while (countYear < 12)
{
    double grade = double.Parse(Console.ReadLine());

    sumGrade += grade;

    if (grade < 4.00)
    {
        countFails++;
        if (countFails == 2)
        {
            Console.WriteLine($"{name} has been excluded at {countYear} grade");
            break;
        }
    }
    countYear++;
    
}

if (countFails != 2)
{
    Console.WriteLine($"{name} graduated. Average grade: {sumGrade / countYear:f2}");
}
