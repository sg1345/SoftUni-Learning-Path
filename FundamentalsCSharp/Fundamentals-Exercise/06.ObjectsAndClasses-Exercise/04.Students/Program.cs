internal class Program
{
    static void Main()
    {
        List<Student> students = new();
        
        

        int numberOfStudents = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfStudents; i++)
        {
            string[] input = Console.ReadLine().Split();

            Student newStudent = new();
            newStudent.FirstName = input[0];
            newStudent.LastName = input[1];
            newStudent.Grade = double.Parse(input[2]);

            students.Add(newStudent);            
        }

        students = students.OrderByDescending(x => x.Grade).ToList();

        foreach (Student student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
        }
    }
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }
}