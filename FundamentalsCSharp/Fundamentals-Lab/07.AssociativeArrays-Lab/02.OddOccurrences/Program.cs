internal class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().ToLower().Split();

        Dictionary<string, int> wordsCounter = new();

        foreach (string word in words)
        {
            if (wordsCounter.ContainsKey(word))
            {
                wordsCounter[word]++;
                continue;
            }

            wordsCounter[word] = 1;
        }

        foreach (KeyValuePair<string, int> wordCount in wordsCounter)
        {
            if (wordCount.Value % 2 == 1)
            {
                Console.Write($"{wordCount.Key} ");
            }
        }
    }
}