namespace _05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()!) != "END")
            {
                string[] command = input.Split(' ',
                    StringSplitOptions.RemoveEmptyEntries);

                string name = command[0];
                int age = int.Parse(command[1]);
                string town = command[2];

                Person person = new(name, age, town);
                people.Add(person);
            }

            int totalNumberOfPeople = people.Count;

            int index = int.Parse(Console.ReadLine()!) - 1;
            Person personToCompare = people[index];
            people.RemoveAt(index);

            int totalCountMatches = 1;
            int numberNotEqual = 0;

            foreach (Person person in people)
            {
                if (personToCompare.CompareTo(person) == 1)
                {
                    totalCountMatches++;
                }
                else
                {
                    numberNotEqual++;
                }
            }

            //if (totalCountMatches == 1)
            //{
            //    totalCountMatches = 0;
            //}

            if (totalCountMatches == 1)
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine($"{totalCountMatches} {numberNotEqual} {totalNumberOfPeople}");
        }
    }
}
