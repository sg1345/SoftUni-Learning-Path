internal class Program
{
    static void Main()
    {
        char[] chars = Console.ReadLine().ToCharArray();

        Stack<char> stack = new Stack<char>(chars);

        foreach (var element in stack)
        {
            Console.Write(element);
        }

    }
}
