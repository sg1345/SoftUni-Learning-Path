using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string patternLetters = @"[A-Za-z]";
        string patternDigits = @"\d";

        string[] competitors = Console.ReadLine()
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();

        Dictionary<string, int> racerDistance = new();
        for (int i = 0; i < competitors.Length; i++)
        {
            racerDistance.Add(competitors[i], 0);
        }

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "end of race")
        {
            MatchCollection digits = Regex.Matches(command, patternDigits);
            int distance = digits.Select(digit => int.Parse(digit.Value)).Sum();

            MatchCollection letters = Regex.Matches(command, patternLetters);
            string name = string.Concat(letters);

            if (competitors.Contains(name))
            {
                racerDistance[name] += distance;
            }
        }

        var ordered = racerDistance
            .OrderByDescending(x => x.Value)
            .Take(3)
            .ToDictionary(k => k.Key, v => v.Value);

        int count = 0;
        foreach (string racer in ordered.Keys)
        {
            count++;
            string place = GeneratePlace(count);
            Console.WriteLine($"{place} place: {racer}");
        }
    }

    static string GeneratePlace(int count)
    {
        if (count == 1)
        {
            return "1st";
        }
        else if (count == 2)
        {
            return "2nd";
        }

        return "3rd";
    }
}
