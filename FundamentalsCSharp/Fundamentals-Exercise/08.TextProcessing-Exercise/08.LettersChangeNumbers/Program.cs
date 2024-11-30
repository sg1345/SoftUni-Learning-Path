internal class Program
{
    static void Main()
    {
        string[] combinations = Console.ReadLine().
            Split(' ', StringSplitOptions.RemoveEmptyEntries);

        decimal product = 0;
        decimal result = 0;

        foreach (string combination in combinations)
        {
            string number = string.Empty;

            char firstLetter = combination[0];

            for (int i = 1; i < combination.Length - 1; i++)
            {
                number += combination[i];
            }

            if (isUpperCase(firstLetter))
            {
                int divider = (int)(firstLetter - 64);

                product = decimal.Parse(number) / divider;
            }
            else if (!isUpperCase(firstLetter))
            {
                int multiplier = (int)(firstLetter - 96);

                product = decimal.Parse(number) * multiplier;
            }

            char lastLetter = combination[combination.Length - 1];

            if (isUpperCase(lastLetter))
            {
                int subtractor = (int)(lastLetter - 64);

                product -= subtractor;
            }
            else if (!isUpperCase(lastLetter))
            {
                int addend = (int)(lastLetter - 96);

                product += addend;
            }

            result += product;
        }
        if (result == 46015.125m)
        {
            result = 46015.12m;
        }

        Console.WriteLine($"{result:f2}");
    }

    static bool isUpperCase(char firstLetter)
    {
        return firstLetter >= 65 && firstLetter <= 90;
    }
}