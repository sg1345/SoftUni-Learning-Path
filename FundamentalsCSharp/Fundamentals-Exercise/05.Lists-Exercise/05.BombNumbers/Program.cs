internal class Program
{
    static void Main()
    {
        List<int> field = ReadListOfIntegers(); // 1 2 1 1 1 1 1 2 1

        var input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var bomb = input[0];  //2
        var power = input[1]; // 2

        var detonation = 0;

        while ((detonation = field.FindIndex(place => place == bomb)) != -1) // detonation = 1 // detonation = 3
        {
            var leftBorder = detonation - power; // left = -1 // left = 1

            if (leftBorder < 0) // true // false
            {
                leftBorder = 0; // left = 0
            }

            var rightBorder = detonation + power; // right = 3 // right =  5

            if (rightBorder > field.Count - 1) // false // true
            {
                rightBorder = field.Count - 1; //       // right = 4
            }

            var areaOfExplosion = rightBorder - leftBorder + 1; // area = 4 // area =  4 - 1 + 1 = 4

            field.RemoveRange(leftBorder, areaOfExplosion);// [0 1 2 3] => [0 1 2 3 4] // [1 2 3 4] => [0]
                                                           // [1 2 1 1] => [1 1 1 2 1] // [1 1 2 1] => [1]
        }

        Console.WriteLine(field.Sum()); // 1
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