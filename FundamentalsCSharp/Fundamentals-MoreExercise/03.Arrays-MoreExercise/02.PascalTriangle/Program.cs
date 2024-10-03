
using System.Threading.Channels;

internal class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int[] helpingArr = new int[number];

        for (int i = 1; i <= number; i++)
        {
            int[] array = new int[i];

            array[0] = 1;
            array[array.Length - 1] = 1;

            for (int j = 0; j < array.Length; j++)
            {
                if (array.Length == 1)
                {
                    break;
                }

                if (array.Length == 2)
                {
                    break;
                }

                if (j == 0)
                {
                    continue;
                }

                if (j == array.Length - 1)
                {
                    break;
                }

                array[j] = helpingArr[j] + helpingArr[j - 1];
            }

            for (int j = 0; j < array.Length; j++)
            {
                helpingArr[j] = array[j];
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}