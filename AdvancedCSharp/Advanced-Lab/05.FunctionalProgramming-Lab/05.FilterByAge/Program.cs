
namespace _05.FilterByAge
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {


        static void Main(string[] args)
        {
            List<Person> people = new();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();           

            Func<Person, bool> filter = AgeFilter(condition, ageThreshold);
            Action<Person> printer = PrintPerson(format);

            people = people.Where(filter).ToList();

            foreach (Person person in people)
            {
                printer(person);
            }
        }

        static Action<Person> PrintPerson(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine(person.Name);

                case "age":
                    return person => Console.WriteLine(person.Age);

                default:
                    return person => Console.WriteLine($"{person.Name} - {person.Age}");

            }
        }

        static Func<Person, bool> AgeFilter(string condition, int ageThreshold)
        {

            switch (condition)
            {
                case "older":
                    return x => x.Age >= ageThreshold;

                default:
                    return y => y.Age < ageThreshold;

            }
        }
    }
}