internal class Program
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split();

        int length = text[0].Length < text[1].Length ? text[0].Length : text[1].Length;

        int result = 0;
        for (int i = 0; i < length; i++)
        {
            int multiply = (int)text[0][i] * (int)text[1][i];

            result += multiply;
        }

        result += SumRestOfTheChars(length, text);

        Console.WriteLine(result);
    }

    static int SumRestOfTheChars(int length, string[] text)
    {
        int result = 0;

        if (length < text[0].Length)
        {
            for (int i = length; i < text[0].Length; i++)
            {
                result += (int)text[0][i];
            }
        }
        else
        {
            for(int i = length; i < text[1].Length; i++)
            {
                result += text[1][i];
            }
        }

        return result;
    }
}