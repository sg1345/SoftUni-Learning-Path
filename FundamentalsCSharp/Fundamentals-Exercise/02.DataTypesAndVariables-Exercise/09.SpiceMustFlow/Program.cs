internal class Program
{
    static void Main()
    {
        var quantity = int.Parse(Console.ReadLine());

        var dayCounter = 0;
        int total = 0;

        while (true)
        {
            if (quantity < 100)
            {                      
                if (total > 26)
                {   
                    total -= 26;
                }

                break;
            }

            total += quantity;
            total -= 26;
            quantity -= 10;
            dayCounter++;
            
        }
        
        Console.WriteLine(dayCounter);
        Console.WriteLine(total);
    }
}