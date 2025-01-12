internal class Program
{
    static void Main()
    {
        Queue<string> playlist = new(Console.ReadLine().Split(',').Select(x => x.Trim()));

        while (true)
        {
            string[] command = Console.ReadLine().Split();

            string song = string.Empty;

            for (int i = 1; i < command.Length; i++)
            {
                song += $"{command[i]} ";
            }
            song = song.Trim();

            switch (command[0])
            {
                case "Play":
                    playlist.Dequeue();

                    if (playlist.Count() == 0)
                    {
                        Console.WriteLine("No more songs!");
                        return;
                    }

                    break;

                case "Add":
                    bool contains = false;
                    for (int i = 0; i < playlist.Count(); i++)
                    {
                        if (song == playlist.Peek())
                        {
                            Console.WriteLine($"{song} is already contained!");
                            contains = true;                            
                        }
                        playlist.Enqueue(playlist.Dequeue());
                    }
                    if (!contains)
                    {
                        playlist.Enqueue(song);
                    }
                    break;

                case "Show":
                    Console.WriteLine(string.Join(", ", playlist));
                    break;
            }
        }
    }
}