internal class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        //continent -> country -> city
        Dictionary<string, Dictionary<string, List<string>>> CitiesByContinentAndCountry = new();

        for (int i = 0; i < number; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string continent = input[0];
            string country = input[1];
            string city = input[2];

            if (!CitiesByContinentAndCountry.ContainsKey(continent))
            {
                CitiesByContinentAndCountry[continent] = new();
            }

            if (!CitiesByContinentAndCountry[continent].ContainsKey(country))
            {
                CitiesByContinentAndCountry[continent][country] = new();
            }

            CitiesByContinentAndCountry[continent][country].Add(city);
        }

        foreach (var (continent, countries) in CitiesByContinentAndCountry)
        {
            Console.WriteLine($"{continent}:");
            foreach(var (country,cities) in countries)
            {
                Console.Write($"  {country} -> ");
                Console.WriteLine(string.Join(", ", cities));
            }
        }
    }
}