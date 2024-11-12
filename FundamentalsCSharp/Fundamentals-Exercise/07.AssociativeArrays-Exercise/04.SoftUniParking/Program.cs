internal class Program
{
    static void Main()
    {
        Dictionary<string, string> namesAndLicensePlates = new();

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] input = Console.ReadLine().Split();

            switch (input[0])
            {
                case "register":

                    if (namesAndLicensePlates.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {input[2]}");
                        continue;
                    }

                    namesAndLicensePlates[input[1]] = input[2];
                    Console.WriteLine($"{input[1]} registered {input[2]} successfully");

                    break;
                case "unregister":

                    if (!namesAndLicensePlates.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: user {input[1]} not found");
                        continue;
                    }

                    namesAndLicensePlates.Remove(input[1]);
                    Console.WriteLine($"{input[1]} unregistered successfully");

                    break;
            }
        }

        foreach (KeyValuePair<string, string> nameAndLicensePlate in namesAndLicensePlates)
        {
            Console.WriteLine($"{nameAndLicensePlate.Key} => {nameAndLicensePlate.Value}");
        }
    }
}