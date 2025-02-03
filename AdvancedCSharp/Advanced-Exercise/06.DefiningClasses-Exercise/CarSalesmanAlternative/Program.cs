using System.Drawing;

namespace CarSalesmanAlternative
{
    public class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Engine> engines = new();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);
                int? displacement = null;
                string? efficiency = null;

                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int value))
                    {
                        displacement = value;
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                }

                engines[model] = new(model, power, displacement, efficiency);
            }

            number = int.Parse(Console.ReadLine());

            List<Car> cars = new();
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines[input[1]];
                int? weight = null;
                string? color = null;

                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int value))
                    {
                        weight = value;
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }

                cars.Add(new(model, engine, weight, color));
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}