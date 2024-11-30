

using System.Collections.Specialized;
using System.Text.RegularExpressions;

public class DecryptedMessage
{
    public DecryptedMessage(string planetName, int population, char attackType, int soldierCount)
    {
        PlanetName = planetName;
        Population = population;
        AttackType = attackType;
        SoldierCount = soldierCount;
    }



    public string PlanetName { get; set; }
    public int Population { get; set; }
    public char AttackType { get; set; }
    public int SoldierCount { get; set; }
}

internal class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        Dictionary<string, DecryptedMessage> orderedMessages = new();

        for (int i = 0; i < count; i++)
        {
            string encryptedMessage = Console.ReadLine();

            string countPattern = @"[SsTtAaRr]";
            string pattern = @"\@(?<name>[A-Z][a-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*\!(?<command>[AD])\![^@\-!:>]*\-\>(?<soldiers>\d+)";

            MatchCollection keyMatch = Regex.Matches(encryptedMessage, countPattern);

            int key = keyMatch.Count;

            string decryptedMessage = string.Empty;
            foreach (char symbol in encryptedMessage)
            {
                decryptedMessage += (char)(symbol - key);
            }

            Match match = Regex.Match(decryptedMessage, pattern);
            if (!match.Success)
            {
                continue;
            }

            DecryptedMessage order = new
                (
                    match.Groups["name"].Value,
                    int.Parse(match.Groups["population"].Value),
                    char.Parse(match.Groups["command"].Value),
                    int.Parse(match.Groups["soldiers"].Value)
                );

            orderedMessages.Add(match.Groups["name"].Value, order);
        }

        orderedMessages = orderedMessages.OrderBy(x => x.Key).ToDictionary(x => (string)x.Key, x => x.Value);

        int attackCounter = AttackedCounter(orderedMessages);
        int destroyedCounter = DestroyedCounter(orderedMessages);

        Console.WriteLine($"Attacked planets: {attackCounter}");
        foreach (KeyValuePair<string, DecryptedMessage> message in orderedMessages)
        {

            if (message.Value.AttackType == 'A')
            {
                Console.WriteLine($"-> {message.Key}");
            }
        }

        Console.WriteLine($"Destroyed planets: {destroyedCounter}");
        foreach (KeyValuePair<string, DecryptedMessage> message in orderedMessages)
        {

            if (message.Value.AttackType == 'D')
            {
                Console.WriteLine($"-> {message.Key}");
            }
        }
    }

    static int AttackedCounter(Dictionary<string, DecryptedMessage> orderedMessages)
    {
        int attackedCount = orderedMessages.Where(x => x.Value.AttackType == 'A')
            .ToDictionary(x => (string)x.Key, y => y.Value)
            .Count();

        //foreach (KeyValuePair<string, DecryptedMessage> message in orderedMessages)
        //{
        //    if (message.Value.AttackType == 'A')
        //    {
        //        attackedCount++;
        //    }
        //}

        return attackedCount;
    }
    static int DestroyedCounter(Dictionary<string, DecryptedMessage> orderedMessages)
    {
        int destroyedCount = orderedMessages.Where(x => x.Value.AttackType == 'D')
            .ToDictionary(x => (string)x.Key, y => y.Value)
            .Count();

        //foreach (KeyValuePair<string, DecryptedMessage> message in orderedMessages)
        //{
        //    if (message.Value.AttackType == 'D')
        //    {
        //        destroyedCount++;
        //    }
        //}

        return destroyedCount;
    }
}