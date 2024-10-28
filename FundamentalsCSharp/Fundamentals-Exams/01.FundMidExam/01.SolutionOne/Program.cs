internal class Program
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        int people = int.Parse(Console.ReadLine());
        double energy = double.Parse(Console.ReadLine());
        double waterPerDay = double.Parse(Console.ReadLine());
        double foodPerDay = double.Parse(Console.ReadLine());

        double water = days * people * waterPerDay;
        double food = days * people * foodPerDay;


        for (int i = 1; i <= days; i++)
        {
            double choppingWood = double.Parse(Console.ReadLine());

            energy -= choppingWood;

            if (energy <= 0)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {food:f2} food and {water:f2} water.");
                return;
            }

            if (i % 2 == 0) // drinking water
            {
                water *= 0.7;
                energy *= 1.05;
            }

            if (i % 3 == 0) // eating food
            {
                food -= food/people;
                energy *= 1.1;
            }

        }

        Console.WriteLine($"You are ready for the quest. You will be left with {energy:f2} energy!");

    }
}