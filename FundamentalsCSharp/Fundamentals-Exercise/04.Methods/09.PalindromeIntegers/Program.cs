
internal class Program
{
    static void Main()
    {
        var input = "";
        while ((input = Console.ReadLine()) != "END")
        {
            PrintIsPalindrome(input);
        }
    }

    static void PrintIsPalindrome(string input)
    {
        var reveresed = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reveresed += input[i];
        }

        if (reveresed == input)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }

    }
}
