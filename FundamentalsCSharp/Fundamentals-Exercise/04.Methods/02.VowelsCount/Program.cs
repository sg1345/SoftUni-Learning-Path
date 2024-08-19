
internal class Program
{
    static void Main()
    {
        var text = Console.ReadLine().ToLower();

        PrintNumberOfVowels(text);
    }

    static void PrintNumberOfVowels(string text)
    {
        var counter = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i]=='a'|| text[i]=='e'
                || text[i]=='i' || text[i]=='o'
                || text[i] == 'u')
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
