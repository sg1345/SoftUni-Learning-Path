internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine().Replace(" ", "");

        Dictionary<char, int> counterSymbols = new();
        
        foreach(char item in text)
        {
            if (counterSymbols.ContainsKey(item))
            {
                counterSymbols[item]++;
                continue;
            }

            counterSymbols.Add(item, 1);
        }

        foreach (KeyValuePair<char, int> countSymbol in counterSymbols)
        {
            Console.WriteLine($"{countSymbol.Key} -> {countSymbol.Value}");
        }
    }
}
