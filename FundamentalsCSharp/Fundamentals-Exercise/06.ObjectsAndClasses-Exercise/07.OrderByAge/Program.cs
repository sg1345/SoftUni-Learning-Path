class Person
{
    public Person(string name, string id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }
    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
}

internal class Program
{
    static void Main()
    {
        List<Person> people = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split();

            Person currentPerson = new(info[0], info[1], int.Parse(info[2]));

            int updateIndex = people.FindIndex(person => person.Id == currentPerson.Id);
            if (updateIndex >= 0)
            {
                people.RemoveAt(updateIndex);
                people.Insert(updateIndex, currentPerson);
                continue;
            }

            people.Add(currentPerson);
        }

        people = people.OrderBy(person => person.Age).ToList();

        foreach (Person person in people)
        {
            Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
        }
    }
}
