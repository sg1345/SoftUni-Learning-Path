internal class Program
{
    static void Main()
    {
        var character = char.Parse(Console.ReadLine());

        if (character >= 'A' && character <= 'Z')
        {
            Console.WriteLine("upper-case");
        }
        else if (character >= 'a' && character <= 'z')
        {
            Console.WriteLine("lower-case");
        }
    }
}
