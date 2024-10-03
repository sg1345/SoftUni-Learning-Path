/*
0 1 2 3
5 2 4 6
 
 
 
 */

internal class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        
        int[] foldArray = new int[array.Length / 2];
        int reversingIndex = (array.Length / 4) - 1;

        for (int i = 0; i < foldArray.Length / 2; i++)
        {
            foldArray[i] = array[reversingIndex];
            reversingIndex--;
        }

        reversingIndex = (array.Length / 2) + (array.Length / 4);

        for (int i = foldArray.Length - 1; i >= foldArray.Length / 2; i--)
        {
            foldArray[i] = array[reversingIndex];
            reversingIndex++;
        }

        int[] sumArray = new int[array.Length / 2];
        int sumIndex = array.Length / 4;

        for (int i = 0; i < foldArray.Length; i++)
        {
            sumArray[i] = foldArray[i] + array[sumIndex];
            sumIndex++;
        }

        Console.WriteLine(string.Join(' ', sumArray));
    }
}

