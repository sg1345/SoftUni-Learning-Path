internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        //color -> clothing -> count
        Dictionary<string, Dictionary<string, int>> wardrobe = new();

        for (int i = 0; i < length; i++)
        {
            string[] input = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            string color = input[0];

            string[] clothes = input[1]
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>x.Trim())
                .ToArray();

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new();
            }

            foreach (var clothing in clothes)
            {
                if (!wardrobe[color].ContainsKey(clothing))
                {
                    wardrobe[color][clothing] = 1;
                    continue;
                }

                wardrobe[color][clothing]++;
            }

        }

        string[] searchedWear = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string colorOfsearchedWear = searchedWear[0];
        string wear = searchedWear[1];

        foreach (var (color, clothes) in wardrobe)
        {
            Console.WriteLine($"{color} clothes:");

            foreach (var (clothing, count) in clothes)
            {
                if (color.Equals(colorOfsearchedWear) && clothing.Equals(wear))
                {
                    Console.WriteLine($"* {clothing} - {count} (found!)");
                    continue;
                }

                Console.WriteLine($"* {clothing} - {count}");
            }
        }
    }
}