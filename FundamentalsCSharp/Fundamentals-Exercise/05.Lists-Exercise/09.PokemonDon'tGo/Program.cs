internal class Program
{
    static void Main()
    {
        List<int> field = ReadListOfIntegers();

        List<int> pokeDex = new List<int>();

        while (field.Count != 0)
        {
            var location = int.Parse(Console.ReadLine());

            var capturedPokemon = 0;

            if (location < 0)
            {
                capturedPokemon = field.First();
                pokeDex.Add(capturedPokemon);

                GameProcessBasedOnDecision(field, location);

            }
            else if (location > field.Count - 1)
            {
                capturedPokemon = field.Last();
                pokeDex.Add(capturedPokemon);

                GameProcessBasedOnDecision(field, location);
            }
            else
            {
                capturedPokemon = field[location];
                pokeDex.Add(capturedPokemon);
             
                GameProcessBasedOnDecision(field, location);

            }

            for (int i = 0; i < field.Count; i++)
            {
                if (field[i] > capturedPokemon)
                {
                    field[i] -= capturedPokemon;
                }
                else
                {
                    field[i] += capturedPokemon;
                }
            }
        }

        Console.WriteLine(pokeDex.Sum());
    }

    static void GameProcessBasedOnDecision(List<int> list, int index)
    {
        if (index < 0)
        {
            index = 0;
            list.RemoveAt(index);
            var copyElement = list.Last();
            list.Insert(index, copyElement);
        }
        else if (index > list.Count - 1)
        {
            index = list.Count - 1;
            list.RemoveAt(index);
            var copyElement = list.First();
            list.Insert(index, copyElement);
        }
        else
        {
            list.RemoveAt(index);
        }
    }

    static List<int> ReadListOfIntegers(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(int.Parse).ToList();
    }
    static List<double> ReadListOfDoubles(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(double.Parse).ToList();
    }
    static List<String> ReadListOfStrings(string separator = " ")
    {
        return Console.ReadLine().Split(separator).ToList();
    }

    static void PrintListOfIntegers(List<int> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfDoubles(List<double> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfStrings(List<string> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintArrayOfIntegers(int[] array, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, array));
    }
}