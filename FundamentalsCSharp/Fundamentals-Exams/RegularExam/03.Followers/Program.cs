
public class Account
{
    public Account(string username, int likes, int comments)
    {
        Username = username;
        Likes = likes;
        Comments = comments;
    }

    public string Username { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }
}

internal class Program
{
    static void Main()
    {
        Dictionary<string, Account> followersActivity = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Log out")
        {
            string[] command = input.Split(':', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            switch (command[0])
            {
                case "New follower":

                    string username = command[1];

                    if (followersActivity.ContainsKey(username))
                    {
                        continue;
                    }

                    Account newFollower = new(command[1], 0, 0);

                    followersActivity.Add(newFollower.Username, newFollower);

                    break;

                case "Like":

                    username = command[1];
                    int likes = int.Parse(command[2]);

                    if (followersActivity.ContainsKey(username))
                    {
                        followersActivity[username].Likes += likes;
                    }
                    else
                    {
                        newFollower = new(username, likes, 0);

                        followersActivity.Add(newFollower.Username, newFollower);
                    }
                    break;

                case "Comment":

                    username = command[1];


                    if (followersActivity.ContainsKey(username))
                    {
                        followersActivity[username].Comments += 1;
                    }
                    else
                    {
                        newFollower = new(username, 0, 1);

                        followersActivity.Add(newFollower.Username, newFollower);
                    }

                    break;

                case "Blocked":
                    username = command[1];
                    if (followersActivity.Remove(username))
                    {

                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    break;
            }
        }
       
        Console.WriteLine($"{followersActivity.Count} followers");

        foreach (KeyValuePair<string, Account> follower in followersActivity)
        {
            Console.WriteLine($"{follower.Key}: {follower.Value.Comments + follower.Value.Likes}");
        }
    }
}
