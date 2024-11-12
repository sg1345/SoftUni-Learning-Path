internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        string numbers = string.Empty;
        string letters = string.Empty;
        string others = string.Empty;

        foreach(char symbol in text)
        {
            if (char.IsDigit(symbol))
            {
                numbers += symbol;
                continue;
            }

            if (char.IsLetter(symbol))
            {
                letters += symbol;
                continue;
            }

            others += symbol;
        }

        Console.WriteLine(numbers);
        Console.WriteLine(letters);
        Console.WriteLine(others);
    }
}
