internal class Program
{
    static void Main()
    {
        var numberCount = int.Parse(Console.ReadLine());

        for (char firstLetter = 'a'; firstLetter < 'a'+numberCount; firstLetter++)
        {
            for (char secondletter = 'a'; secondletter < 'a' + numberCount; secondletter++)
            {
                for (char thirdLetter = 'a'; thirdLetter < 'a' + numberCount; thirdLetter++)
                {
                    Console.WriteLine($"{firstLetter}{secondletter}{thirdLetter}");
                }
            }
        }
    }
}