internal class Program
{
    static void Main()
    {
        
        List<string> list = new (Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));

        Dictionary<string, int> countSameValues = new();

        foreach (string number in list)
        {
            if (countSameValues.ContainsKey(number))
            {
                countSameValues[number]++;
            }
            else
            {
                countSameValues.Add(number, 1);
            }
        }

        foreach(var(number,count) in countSameValues)
        {
            Console.WriteLine($"{number} - {count} times");
        }
    }
}