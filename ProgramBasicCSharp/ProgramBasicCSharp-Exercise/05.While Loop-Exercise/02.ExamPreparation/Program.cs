

int failedThreshold = int.Parse(Console.ReadLine());

int countFails = 0;
int countProblems = 0;

int sumAllGrades = 0;

string lastProblem = "";

bool isValid = false;

while (failedThreshold > countFails)
{
    string problemName = Console.ReadLine();
   
    if (problemName == "Enough")
    {
        isValid = true;
        break;
    }

    int grade = int.Parse(Console.ReadLine());

    sumAllGrades += grade;
    
    countProblems++;

    if (grade <= 4)
    {
        countFails++;
    }

    lastProblem = problemName;
}

if (isValid)
{
    Console.WriteLine($"Average score: {(double)sumAllGrades/countProblems:f2}");
    Console.WriteLine($"Number of problems: {countProblems}");
    Console.WriteLine($"Last problem: {lastProblem}");
}
else
{
    Console.WriteLine($"You need a break, {countFails} poor grades.");
}


