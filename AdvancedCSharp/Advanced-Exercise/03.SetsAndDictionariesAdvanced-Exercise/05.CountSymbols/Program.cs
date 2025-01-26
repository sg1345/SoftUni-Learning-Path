internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        Dictionary<char, int> map = new Dictionary<char, int>();

        foreach (char letter in input)
        {
            if (map.ContainsKey(letter))
            {
                map[letter]++;
                continue;
            }
            map.Add(letter, 1);
        }

        map = map.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);

        foreach (var (letter, count) in map)
        {
            Console.WriteLine($"{letter}: {count} time/s");
        }
    }
}
