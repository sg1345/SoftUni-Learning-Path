using System.Drawing;

namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<Engine> engines = new();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);

                if (input.Length == 2)
                {
                    engines.Add(new(model, power));
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int displacement))
                    {
                        engines.Add(new(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = input[2];
                        engines.Add(new(model, power, efficiency));
                    }

                }
                else
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                    engines.Add(new(model, power, displacement, efficiency));
                }
            }

            number = int.Parse(Console.ReadLine());

            List<Car> cars = new();
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines.Find(x => x.Model == input[1]);

                if (input.Length == 2)
                {
                    Car car = new(model, engine);
                    cars.Add(car);
                }
                else if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int weight))
                    {
                        // Car car = new(input[0], engine, weight);
                        cars.Add(new(model, engine, weight));
                    }
                    else
                    {
                        string color = input[2];
                        cars.Add(new(model, engine, color));
                    }
                }
                else
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];
                    Car car = new(input[0], engine, weight, color);
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}