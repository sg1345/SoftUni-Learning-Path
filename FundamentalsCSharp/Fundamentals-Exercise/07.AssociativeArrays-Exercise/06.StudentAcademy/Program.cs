internal class Program
{
    static void Main()
    {
        Dictionary<string, List<double>> studentsGrades = new();

        int studentCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if (!studentsGrades.ContainsKey(student))
            {
                studentsGrades[student] = new();
            }

            studentsGrades[student].Add(grade);
        }

        foreach (KeyValuePair<string, List<double>> studentGrades in studentsGrades)
        {
            var averageGrade = studentGrades.Value.Average();

            if (averageGrade >= 4.5)
            {
                Console.WriteLine($"{studentGrades.Key} -> {averageGrade:f2}");
            }
        }
    }
}