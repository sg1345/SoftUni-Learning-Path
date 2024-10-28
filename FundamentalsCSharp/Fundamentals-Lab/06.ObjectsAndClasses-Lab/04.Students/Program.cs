internal class Program
{
    static void Main()
    {
        List<StudentData> studentList = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] info = input.Split();

            StudentData student = new();
            student.FirstName = info[0];
            student.LastName = info[1];
            student.Age = int.Parse(info[2]);
            student.HomeTown =info[3];

            studentList.Add(student);
        }

        string filter = Console.ReadLine();
        
        foreach(StudentData student in studentList)
        {
            if (student.HomeTown == filter)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}

class StudentData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HomeTown { get; set; }
    public int Age { get; set; }
}
