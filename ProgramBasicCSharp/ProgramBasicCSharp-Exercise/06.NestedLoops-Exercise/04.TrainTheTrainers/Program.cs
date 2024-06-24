
int judges = int.Parse(Console.ReadLine());

int countPresentations = 0;
double finalGrade = 0;

while (true)
{   

    string presentationName = Console.ReadLine();

    if (presentationName == "Finish")
    {
        Console.WriteLine($"Student's final assessment is {finalGrade/countPresentations:f2}.");
        break;
    }

    double sumOfGradesPerPresentation = 0;
    for (int i = 0; i < judges; i++)
    {
        double grade = double.Parse(Console.ReadLine());
        sumOfGradesPerPresentation += grade;
    }
    double averageGradePerPresentation = sumOfGradesPerPresentation / judges;
    Console.WriteLine($"{presentationName} - {averageGradePerPresentation:f2}.");
    finalGrade += averageGradePerPresentation;
    countPresentations++;
    
}