internal class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] lisLength = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            int tempNumber = array[i];
            int sequenceCounter = 1;

            for (int j = i; j >= 0; j--)
            {
                if (j == i && i == 0)
                {
                    sequenceCounter = 1;
                    break;
                }

                if (tempNumber > array[j])
                {
                    sequenceCounter++;
                    tempNumber = array[j];                    
                }
            }

            lisLength[i] = sequenceCounter;
        }
    }
}

