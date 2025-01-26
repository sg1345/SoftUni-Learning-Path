internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        Dictionary<string, int> numbers = new();

        for (int i = 0; i < length; i++)
        {
            string input = Console.ReadLine();
            if (numbers.ContainsKey(input))
            {
                numbers[input]++;
                continue;
            }

            numbers[input] = 1;
        }

        foreach (var (number, count) in numbers)
        {
            if (count % 2 == 0)
            {
                Console.WriteLine(number);
                return;
            }
        }
    }
}