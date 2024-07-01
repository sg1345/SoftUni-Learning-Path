internal class Program
{
    static void Main()
    {
        var recieveWaterCounter = byte.Parse(Console.ReadLine());

        var capacity = (ushort)0;

        for (int i = 0; i < recieveWaterCounter; i++)
        {
            var litersRecieved = ushort.Parse(Console.ReadLine());

            if (litersRecieved + capacity <= 255)
            {
                capacity += litersRecieved;
            }
            else
            {
                Console.WriteLine("Insufficient capacity!");
            }
        }

        Console.WriteLine(capacity);
    }

}