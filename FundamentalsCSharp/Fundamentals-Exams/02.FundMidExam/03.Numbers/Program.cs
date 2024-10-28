internal class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        double avgNumber = numbers.Sum() / (double)numbers.Count;

        numbers = numbers.Where(number => avgNumber < number).ToList();
        
        if(numbers.Count == 0)
        {
            Console.WriteLine("No");
            return;
        }

        numbers = numbers.OrderByDescending(number => number).ToList();


        while (numbers.Count > 5)
        {
            numbers.RemoveAt(numbers.Count - 1);
        }

        Console.WriteLine(string.Join(' ', numbers));
    }
}
