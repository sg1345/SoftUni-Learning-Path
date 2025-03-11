using _05.BirthdayCelebrations.Abstraction;

namespace _05.BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdate> list = new();

            string command;
            while ((command = Console.ReadLine()!) != "End")
            {
                string[] data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (data[0] == nameof(Citizen))
                {
                    Citizen citizen = new(data[1], int.Parse(data[2]), data[3], data[4]);
                    list.Add(citizen);
                }
                else if (data[0] == nameof(Pet))
                {
                    Pet pet = new(data[1], data[2]);
                    list.Add(pet);
                }
            }

            string marker = Console.ReadLine()!;

            foreach (var id in list.Where(x => x.Birthdate.EndsWith(marker)))
            {
                Console.WriteLine(id.Birthdate);
            }
        }
    }
}
