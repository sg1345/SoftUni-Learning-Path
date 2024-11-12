internal class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> coursesStudents = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] arguments = input.Split(':').Select(text => text.Trim()).ToArray();

            if (!coursesStudents.ContainsKey(arguments[0]))
            {
                coursesStudents[arguments[0]] = new();
            }

            if (coursesStudents[arguments[0]].Contains(arguments[1]))
            {
                continue;
            }

            coursesStudents[arguments[0]].Add(arguments[1]);
        }

        foreach (KeyValuePair<string, List<string>> courseStudents in coursesStudents)
        {
            Console.WriteLine($"{courseStudents.Key}: {courseStudents.Value.Count}");
            
            Console.WriteLine("-- " + string.Join("\n-- ",courseStudents.Value));
        }
    }
}