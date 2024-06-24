
int countStudents = int.Parse(Console.ReadLine());

int countFail = 0;
int countAverageStudents = 0;
int countGoodStudents = 0;
int countTopStudents = 0;

double sumGrades  = 0;

for (int i = 0; i < countStudents; i++)
{
    double grade = double.Parse(Console.ReadLine());

    sumGrades += grade;

    if (grade < 3.00)
    {
        countFail++;
    }
    else if (grade < 4.00)
    {
        countAverageStudents++;
    }
    else if (grade < 5.00)
    {
        countGoodStudents++;
    }
    else
    {
        countTopStudents++;
    }
}

Console.WriteLine($"Top students: {100.0 * countTopStudents / (countTopStudents + countGoodStudents + countAverageStudents + countFail):F2}%");
Console.WriteLine($"Between 4.00 and 4.99: {100.0 * countGoodStudents / (countTopStudents + countGoodStudents + countAverageStudents + countFail):F2}%");
Console.WriteLine($"Between 3.00 and 3.99: {100.0 * countAverageStudents / (countTopStudents + countGoodStudents + countAverageStudents + countFail):F2}%");
Console.WriteLine($"Fail: {100.0 * countFail / (countTopStudents + countGoodStudents + countAverageStudents + countFail):F2}%");
Console.WriteLine($"Average: {sumGrades / (countTopStudents + countGoodStudents + countAverageStudents + countFail):F2}");