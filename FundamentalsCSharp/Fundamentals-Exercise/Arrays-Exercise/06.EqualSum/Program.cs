internal class Program
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();


        for (int i = 0; i < array.Length; i++)
        {
            var leftSum = 0;
            var rightSum = 0;

            if (i != 0)
            {
                for (int j = i - 1;  j >= 0;  j--)
                {
                    leftSum += array[j];
                }
            }
            if (i != array.Length - 1)
            {
                for (int k = i +1; k < array.Length; k++)
                {
                    rightSum += array[k];
                }
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine(i);
                break;
            }
            if (i == array.Length - 1 && leftSum != rightSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}