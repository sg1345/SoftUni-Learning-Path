namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int filterNumber = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);


            Predicate<int> devisableBySpecialNumber = x => x<=filterNumber;

            List<string> list = new();
            for (int i = 0; i < names.Length; i++)
            {
                if (devisableBySpecialNumber(names[i].Length))
                {
                    list.Add(names[i]);
                }
            }

            Console.WriteLine(string.Join('\n', list));
        }
    }
}