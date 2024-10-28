
internal class Program
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split();

        Random random = new();

        for (int i = 0; i < text.Length; i++)
        {
            int randomIndex = random.Next(text.Length - 1);

            string temp = text[i];
            text[i] = text[randomIndex];
            text[randomIndex] = temp;
        }

        Console.WriteLine(string.Join("\n", text));
    }
}