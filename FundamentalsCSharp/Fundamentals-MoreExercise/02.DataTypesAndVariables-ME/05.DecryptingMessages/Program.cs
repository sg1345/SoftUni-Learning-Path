internal class Program
{
    static void Main()
    {
        int key = int.Parse(Console.ReadLine());

        int length = int.Parse(Console.ReadLine());
        string message = string.Empty;
        for (int i = 0; i < length; i++)
        {
            char letter = char.Parse(Console.ReadLine());
            message += (char)(letter + key);
        }
        Console.WriteLine(message);
    }
}