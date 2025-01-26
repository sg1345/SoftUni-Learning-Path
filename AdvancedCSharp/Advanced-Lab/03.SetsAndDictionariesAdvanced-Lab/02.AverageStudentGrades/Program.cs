internal class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        Dictionary<string, List<decimal>> StudentGrades = new();

        for (int i = 0; i < count; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = input[0];
            decimal grade = decimal.Parse(input[1]);

            if (!StudentGrades.ContainsKey(name))
            {
                StudentGrades[name] = new List<decimal>();
            }

            StudentGrades[name].Add(grade);
        }

        foreach (var (student,grades) in StudentGrades)
        {
            Console.Write($"{student} -> ");

            foreach (decimal grade in grades)
            {
                Console.Write($"{grade:f2} ");
            }
            
            Console.WriteLine($"(avg: {grades.Average():f2})");
        }
    }
}