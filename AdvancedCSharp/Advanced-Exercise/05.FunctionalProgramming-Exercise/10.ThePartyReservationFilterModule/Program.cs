namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            HashSet<string> addedFilters = new();
            List<string> results = new();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                addedFilters = filterManipulation(addedFilters,input);

                results = names.Select(x => x).ToList();

                foreach (var filterProparty in addedFilters)
                {
                    string[] tokens = filterProparty.Split(';');
                    string criteria = tokens[0];
                    string sample = tokens[1];

                    Func<string, bool> filter = GetFilter(criteria, sample);
                    results = results.Where(name => !filter(name)).ToList();
                }
            }

            Console.WriteLine(string.Join(' ', results));
        }

        static HashSet<string> filterManipulation(HashSet<string> addedFilters, string input)
        {
            string[] command = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string action = command[0];

            if (action == "Add filter")
            {
                addedFilters.Add($"{command[1]};{command[2]}");
            }
            else if (action == "Remove filter")
            {
                addedFilters.Remove($"{command[1]};{command[2]}");
            }

            return addedFilters;
        }

        static Func<string, bool> GetFilter(string criteria, string sample)
        {
            return criteria switch
            {
                "Starts with" => name => name.StartsWith(sample),
                "Ends with" => name => name.EndsWith(sample),
                "Length" => name => name.Length == int.Parse(sample),
                "Contains" => name => name.Contains(sample),
                _ => _ => false
            };
            throw new NotImplementedException();
        }
    }
}
