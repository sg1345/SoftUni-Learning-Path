internal class Program
{
    static void Main()
    {
        string[] userNames = Console.ReadLine().Split(", ");

        foreach (string user in userNames)
        {
            if (user.Length < 3 || user.Length > 16)
            {
                continue;
            }

            int leftsymbolsCount = user.Count
                (
                    symbol => !char.IsLetterOrDigit(symbol) &&
                    symbol != '-' &&
                    symbol != '_'
                );

            if (leftsymbolsCount == 0)
            {
                Console.WriteLine(user);
            }
        }
    }
}