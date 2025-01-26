internal class Program
{
    static void Main()
    {
        HashSet<string> SoftUniParty = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "PARTY")
        {
            SoftUniParty.Add(input);
        }

        while ((input = Console.ReadLine()) != "END")
        {
            SoftUniParty.Remove(input);
        }
        HashSet<string> vip = new();
        HashSet<string> regular = new();

        foreach (var person in SoftUniParty)
        {
            if (person[0] >= '0' && person[0] <= '9')
            {
                vip.Add(person);
            }
            else
            {
                regular.Add(person);
            }
        }

        Console.WriteLine(SoftUniParty.Count);

        foreach (var guest in vip)
        {
            Console.WriteLine(guest);
        }

        foreach (var guest in regular)
        {
            Console.WriteLine(guest);
        }
    }
}