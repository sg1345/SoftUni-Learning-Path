internal class Program
{
    static void Main()
    {
        string[] array = Console.ReadLine()
            .Split();

        var longestSequence = int.MinValue;
        string elementFromLongestSequence = "";

        for (int i = 0; i < array.Length; i++)
        {
            var count = 1;
            
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            
            if (longestSequence < count)
            {
                longestSequence = count;
                elementFromLongestSequence = array[i];                    
            }
        }
        string[] arrayToPrint = new string[longestSequence];

        for (int i = 0; i < longestSequence; i++)
        {
            arrayToPrint[i] = elementFromLongestSequence;
        }

        Console.WriteLine(string.Join(" ",arrayToPrint));
    }
}