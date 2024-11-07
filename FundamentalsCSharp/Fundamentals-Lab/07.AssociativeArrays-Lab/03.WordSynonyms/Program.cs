internal class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        Dictionary<string, string> wordsSynonyms = new();

        string word = string.Empty;
        string synonym = string.Empty;

        for (int i = 0; i < count; i++)
        {
            word = Console.ReadLine();
            synonym = Console.ReadLine();

            if (wordsSynonyms.ContainsKey(word))
            {
                wordsSynonyms[word] += $", {synonym}";
                continue;
            }

            wordsSynonyms.Add(word, synonym);
        }

        foreach(KeyValuePair<string,string> wordSynonym in wordsSynonyms)
        {
            Console.WriteLine($"{wordSynonym.Key} - {wordSynonym.Value}");
        }
    }
}