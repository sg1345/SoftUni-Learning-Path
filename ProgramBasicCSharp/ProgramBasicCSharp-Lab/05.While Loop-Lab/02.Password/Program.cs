
string username = Console.ReadLine();
string password = Console.ReadLine();

while (true)
{
    string enterPassword = Console.ReadLine();

    if (enterPassword == password)
    {
        Console.WriteLine($"Welcome {username}!");
        break;
    }
}