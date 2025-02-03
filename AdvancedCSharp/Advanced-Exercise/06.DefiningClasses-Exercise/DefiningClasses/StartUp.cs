namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //Family people = new();
            List<Person> people = new();
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(int.Parse(input[1]), input[0]);
                //people.AddMember(person);
                people.Add(person);

            }
            //Family sortedPeople = people.GetPeopleOver30();
            List<Person> sortedPeople = people
                .Where(person => person.Age > 30)
                .OrderBy(person => person.Name)
                .ToList();

            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

    }
}
