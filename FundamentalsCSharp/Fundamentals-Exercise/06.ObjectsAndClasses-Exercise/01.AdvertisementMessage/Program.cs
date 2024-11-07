internal class Program
{
    static void Main()
    {
        Message messages = new Message();

        string[] phases =
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };

        messages.Phases = new();
        messages.Phases.AddRange(phases);

        string[] events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        messages.Events = new();
        messages.Events.AddRange(events);

        string[] authors =
        {
            "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
        };
        messages.Authors = new();
        messages.Authors.AddRange(authors);

        string[] cities =
        {
            "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
        };

        messages.Cities = new();
        messages.Cities.AddRange(cities);

        int numberOfAds = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfAds; i++)
        {
            Random random = new Random();

            int randomIndexPhases = random.Next(0, messages.Phases.Count - 1);
            int randomIndexEvents = random.Next(0, messages.Events.Count - 1);
            int randomIndexAuthors = random.Next(0, messages.Authors.Count - 1);
            int randomIndexCities = random.Next(0, messages.Cities.Count - 1);

            Console.WriteLine(
                $"{messages.Phases[randomIndexPhases]} " +
                $"{messages.Events[randomIndexEvents]} " +
                $"{messages.Authors[randomIndexAuthors]} - " +
                $"{messages.Cities[randomIndexCities]} ");

        }
    }
}

class Message
{
    public List<string> Phases { get; set; }
    public List<string> Events { get; set; }
    public List<string> Authors { get; set; }
    public List<string> Cities { get; set; }
}