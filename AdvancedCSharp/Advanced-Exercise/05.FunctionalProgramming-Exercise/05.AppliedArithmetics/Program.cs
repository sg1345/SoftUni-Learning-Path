namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToArray();

            Action<int[], Func<int, int>> operation = (arr, change) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = change(arr[i]);
                }
            };      

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        operation(numbers, number => number + 1);
                        break;
                    case "multiply":
                        operation(numbers, number => number * 2);
                        break;
                    case "subtract":
                        operation(numbers, number => number - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ',numbers));
                        break;
                    default:
                        throw new Exception("error");                       
                }
            }
        }
    }
}