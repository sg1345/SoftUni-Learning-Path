
internal class Program
{
    static void Main()
    {
        var text = Console.ReadLine();
        var repeat = int.Parse(Console.ReadLine());

        var output = StringRepeat(text, repeat);
        Console.WriteLine(output);
    }

    static string StringRepeat(string text, int repeat)
    {
        var output = string.Empty;
        for (int i = 0; i < repeat; i++)
        {
            output += text;
        }
        return output;
    }
}