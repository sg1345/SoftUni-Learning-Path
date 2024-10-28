internal class Program
{
    static void Main()
    {
        int numberOfSongs = int.Parse(Console.ReadLine());

        List<Songs> mySongs = new();

        for (int i = 0; i < numberOfSongs; i++)
        {
            string[] input = Console.ReadLine().Split('_');       

            Songs song = new();
            song.TypeList = input[0];
            song.Name = input[1];
            song.Time = input[2];
            
            mySongs.Add(song);
        }

        string filter = Console.ReadLine();

        foreach (Songs song in mySongs)
        {
            if (filter == "all")
            {
                Console.WriteLine(song.Name);
                continue;
            }
            if(filter == song.TypeList)
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}

class Songs
{
    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }
}