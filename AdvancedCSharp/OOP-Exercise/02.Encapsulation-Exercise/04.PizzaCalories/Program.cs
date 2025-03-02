using System.Runtime.InteropServices;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Pizza pizza = CreateNewPizza();

                string command;
                while ((command = Console.ReadLine()!) != "END")
                {
                    string[] data = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (data[0] == "Topping")
                    {
                        pizza.AddTopping(new Topping(data[1], double.Parse(data[2])));
                    }
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private static Pizza CreateNewPizza()
        {
            string[] pizzaName = Console.ReadLine()!
                    .Split(' ');

            string[] doughInfo = Console.ReadLine()!
                .Split(' ');

            Dough newDough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

            return new(pizzaName[1], newDough);

        }
    }
}
