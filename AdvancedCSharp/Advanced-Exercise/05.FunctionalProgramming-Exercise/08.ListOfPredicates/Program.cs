namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            int[] deviders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int[], bool> filter = (number, deviders) =>
            {
                foreach(int devider in deviders)
                {
                    if(number % devider != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
            List<int> list = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (filter(i, deviders))
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ',list));
        }
    }
}
