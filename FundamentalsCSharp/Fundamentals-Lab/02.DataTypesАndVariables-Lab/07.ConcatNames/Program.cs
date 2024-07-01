internal class Program
{
    static void Main()
    {
        var firstName = Console.ReadLine();
        var lastName = Console.ReadLine();
        var delimeter = Console.ReadLine();

        Console.WriteLine($"{firstName}{delimeter}{lastName}");
    }
}
