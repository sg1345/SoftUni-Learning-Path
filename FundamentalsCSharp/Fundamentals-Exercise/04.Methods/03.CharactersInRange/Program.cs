
internal class Program
{
    static void Main()
    {
        var firstChar = char.Parse(Console.ReadLine());
        var secondChar = char.Parse(Console.ReadLine());

        PrintAllCharactersBetween(firstChar, secondChar);
    }

    static void PrintAllCharactersBetween(char firstChar, char secondChar)
    {
        var result = ' ';

        if (firstChar > secondChar)
        {
            result = secondChar;

            for (char index = secondChar; index < firstChar - 1; index++)
            {
                result++;

                Console.Write(result + " ");
            }
        }
        else
        {
            result = firstChar;

            for(char index = firstChar; index < secondChar - 1; index++)
            {
                result++;

                Console.Write(result + " ");
            }
        }
    }
}
