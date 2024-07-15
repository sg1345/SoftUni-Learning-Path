using System.Threading.Tasks.Dataflow;

internal class Program
{
    static void Main()
    {
        var wagons = int.Parse(Console.ReadLine());

        var people = new int[wagons];

        var sum = 0;

        for (int i = 0; i < wagons; i++)
        {
            people[i] = int.Parse(Console.ReadLine());

            sum += people[i];
        }

        Console.WriteLine(string.Join(" ",people));

        Console.WriteLine(sum);

    }
}