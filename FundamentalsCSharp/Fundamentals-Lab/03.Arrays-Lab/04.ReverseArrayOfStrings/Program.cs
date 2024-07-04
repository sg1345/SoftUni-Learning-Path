internal class Program
{
    static void Main()
    {
        string[] array = Console.ReadLine() // 1 2 3 4 5
                                .Split();

        for (int i = 0; i < array.Length / 2; i++) //0
        {   
            var copyOfString = array [i];    // copyOfArray = 1
            array[i] = array[array.Length -1 - i]; // array[0] = 5
            array[array.Length - 1 - i] = copyOfString; // array[4] = 1
        }

        Console.WriteLine(string.Join(" ", array));

        /*for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.WriteLine($"{array[i]} ");
        }*/
    }
}