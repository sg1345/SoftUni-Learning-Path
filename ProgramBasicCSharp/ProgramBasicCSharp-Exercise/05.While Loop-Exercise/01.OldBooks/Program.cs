
string desiredBook = Console.ReadLine();
int booksChecked = 0;

while (true)
{
    string book = Console.ReadLine();

    if (book == "No More Books")
    {
        Console.WriteLine("The book you search is not here!");
        Console.WriteLine($"You checked {booksChecked} books.");
        break;
    }

    if (book == desiredBook)
    {
        Console.WriteLine($"You checked {booksChecked} books and found it.");
        break;
    }

    booksChecked++;
}

