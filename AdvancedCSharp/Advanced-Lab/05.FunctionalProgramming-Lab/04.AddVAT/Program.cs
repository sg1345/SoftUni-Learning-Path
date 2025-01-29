namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> AddVAT = number => number * 1.2;
            Func<double, string> format = number => $"{number:f2}";

            string[] prices = Console.ReadLine()
                .Split(new string(", "), StringSplitOptions.RemoveEmptyEntries)
                .Select(number => double.Parse(number))
                .Select(AddVAT)
                .Select(format)
                .ToArray();

            //Func<string, string> AddVAT = number => $"{double.Parse(number)*1.2:f2}";

            //string[] prices = Console.ReadLine()
            //    .Split(new string(", "), StringSplitOptions.RemoveEmptyEntries)
            //    .Select(AddVAT)                
            //    .ToArray();

            Console.WriteLine(string.Join("\n", prices));
        }
    }
}
