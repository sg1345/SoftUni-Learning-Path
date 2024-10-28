using System.ComponentModel;
using System.Data;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main()
    {
        List<string> favouriteGenres = Console.ReadLine()
            .Split('|', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Stop!")
        {
            string[] command = input.Split();

            switch (command[0])
            {
                case "Join":
                    AddGenre(favouriteGenres, command[1]);
                    break;

                case "Drop":
                    RemoveGenre(favouriteGenres, command[1]);
                    break;

                case "Replace":
                    ReplaceGenre(favouriteGenres, command[1], command[2]);
                    break;

                case "Prefer":
                    ChangeGenrePlaces(favouriteGenres, int.Parse(command[1]), int.Parse(command[2]));
                    break;
            }
        }

        Console.WriteLine(string.Join(' ', favouriteGenres));
    }

    static void AddGenre(List<string> list, string newGenre)
    {
        if (list.Find(genre => genre == newGenre) != newGenre)
        {
            list.Add(newGenre);
        }
    }

    static void RemoveGenre(List<string> list, string remove)
    {
        if (list.Find(genre => genre == remove) == remove)
        {
            list.Remove(remove);
        }
    }

    static void ReplaceGenre(List<string> list, string oldGenre, string newGenre)
    {
        if (list.Find(genre => genre == newGenre) == newGenre)
        {
            return;
        }
        if (list.Find(genre => genre == oldGenre) != oldGenre)
        {
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == oldGenre)
            {
                list[i] = newGenre;
                break;
            }
        }
    }

    static void ChangeGenrePlaces(List<string> list, int genreIndex1, int genreIndex2)
    {
        if ((genreIndex2 > list.Count - 1 || genreIndex2 < 0) ||
           (genreIndex1 > list.Count - 1 || genreIndex1 < 0))
        {
            return;
        }

        string firstGenre = list[genreIndex1];
        string secondGenre = list[genreIndex2];
        bool isIndex1True = (list.Find(genre => genre == firstGenre) == firstGenre);
        bool isIndex2True = (list.Find(genre => genre == secondGenre) == secondGenre);

        if (isIndex1True && isIndex2True)
        {
            list.Remove(firstGenre);
            list.Insert(genreIndex1, secondGenre);
            list.Remove(secondGenre);
            list.Insert(genreIndex2, firstGenre);

        }
    }
}