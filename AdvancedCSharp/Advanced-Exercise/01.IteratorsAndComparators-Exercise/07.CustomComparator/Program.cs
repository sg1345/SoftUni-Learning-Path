using System.Reflection.Metadata.Ecma335;

namespace _07.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.Sort(new CustomComparator());

            Console.WriteLine(string.Join(' ', numbers));
        }

        class CustomComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int xCompared = Math.Abs(x % 2);
                int yComapred = Math.Abs(y % 2);

                if (xCompared == 0 && yComapred == 0)
                {
                    return x.CompareTo(y);
                }
                else if (xCompared == 0 && yComapred == 1)
                {
                    return -1;
                }
                else if (xCompared == 1 && yComapred == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            }
        }
    }
}