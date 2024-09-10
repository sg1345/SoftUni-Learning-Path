internal class Program
{
    static void Main()
    {
        //1 4 3 2 
        var array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 1)
            {
                Console.Write(array[i]);
            }
            else
            {
                bool isTopInteger = false;
                for(int j = i + 1;  j < array.Length; j++)
                {
                    if (array[i] <= array[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                    isTopInteger = true;
                }
                if (isTopInteger)
                {
                    Console.Write(array[i] + " ");
                }                
            }
        }
    }
}