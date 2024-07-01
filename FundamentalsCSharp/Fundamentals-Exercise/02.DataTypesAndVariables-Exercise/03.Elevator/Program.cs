internal class Program
{
    static void Main()
    {
        var peopleCount = int.Parse(Console.ReadLine());
        var capacity = int.Parse(Console.ReadLine());


        //var result = (int)Math.Ceiling((double)peopleCount/capacity);
        var result = peopleCount / capacity;

        if (peopleCount % capacity != 0 )
        {
            result += 1;
        }
        
        Console.WriteLine(result);
    }
}