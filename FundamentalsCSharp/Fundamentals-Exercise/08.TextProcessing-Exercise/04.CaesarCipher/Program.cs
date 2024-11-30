internal class Program
{
    static void Main()
    {
        char[] symbols = Console.ReadLine().ToCharArray();

        foreach (char symbol in symbols)
        {
            char currentChar = (char)((int)symbol + 3);

            Console.Write(currentChar);
        }
    }
}