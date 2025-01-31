using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> Comparer = GetComparer;
            Action<Func<string, int, bool>, string[]> print = Print(number, Comparer);

            print(Comparer, names);

        }

        static Action<Func<string, int, bool>, string[]> Print
            (int number, Func<string, int, bool> Comparer)
        {
            return (comarer, names) =>
            {
                foreach (var name in names)
                {
                    if (Comparer(name, number))
                    {
                        Console.WriteLine(name);
                        return;
                    }
                }
            };
        }

        static bool GetComparer(string name, int number)
        {
            Func<string, int> NameInNumber = GetTheNumber;
            return NameInNumber(name) >= number;            
        }

        static int GetTheNumber(string Name)
        {
            return Name.Select(x=>(int)x).ToArray().Sum();            
        }
    }
}
