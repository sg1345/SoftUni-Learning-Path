internal class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine() 
            .Split()
            .Select(int.Parse)
            .ToArray();

        // the array gets shorter with each loop
        // until its length = 1
        // When the array's length = 1, then we print the result
        while (1 < array.Length)  
        {
            int[] condense = new int[array.Length - 1];  
            
            for (int i = 0; i < condense.Length; i++)   
            {
                condense[i] = array[i] + array[i+1]; 
            }

            array = condense;
        }

        Console.WriteLine(string.Join("",array));
    }
}