using _06.FoodShortage.Abstraction;
using System.Security.Cryptography.X509Certificates;

namespace _06.FoodShortage
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine()!);

            List<IBuyer> list = new();

            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine()!
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    Rebel rebel = new(data[0], int.Parse(data[1]), data[2]);
                    list.Add(rebel);
                }
                else if (data.Length == 4)
                {
                    Citizen citizen = new(data[0], int.Parse(data[1]), data[2], data[3]);
                    list.Add(citizen);
                }
            }

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                foreach (var item in list)
                {
                    if (item is Citizen citizen && citizen.Name == command)
                    {
                        item.BuyFood();
                    }
                    else if (item is Rebel rebel && rebel.Name == command)
                    {
                        item.BuyFood();                        
                    }
                }
            }

            Console.WriteLine(list.Sum(x=>x.Food));

        }
    }
}
