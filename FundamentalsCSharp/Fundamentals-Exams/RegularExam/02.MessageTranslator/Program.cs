using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        int numberOfCommands = int.Parse(Console.ReadLine());

        string pattern = @"\!(?<command>[A-Z][a-z]{2,})\!\:\[(?<letters>[A-Za-z]{8,})\]";

        for (int i = 0; i < numberOfCommands; i++)
        {
            string message = Console.ReadLine();

            Match match = Regex.Match(message, pattern);

            if (!match.Success)
            {
                Console.WriteLine("The message is invalid");
                continue;
            }

            Console.Write($"{match.Groups["command"].Value}:");
            foreach (char letter in match.Groups["letters"].Value)
            {
                Console.Write(" " + (int)letter);
            }
            Console.WriteLine();
        }
    }
}
