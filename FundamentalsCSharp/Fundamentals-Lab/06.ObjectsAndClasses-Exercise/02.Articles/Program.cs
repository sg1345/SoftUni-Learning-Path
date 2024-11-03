internal class Program
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split(',').Select(s => s.Trim()).ToArray();

        Article arcticle = new(text[0], text[1], text[2]);

        int numberOfEdits = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEdits; i++)
        {
            string[] input = Console.ReadLine().Split(':').Select(s => s.Trim()).ToArray();

            switch (input[0])
            {
                case "Edit":
                    arcticle.Edit(input[1]);

                    break;
                case "ChangeAuthor":
                    arcticle.ChangeAuthor(input[1]);
                    break;
                case "Rename":
                    arcticle.Rename(input[1]);
                    break;
            }
        }

        Console.WriteLine(arcticle);
    }
}
class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Edit(string newContent)
    {
        Content = newContent;
    }
    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }
    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    //public void Print()
    //{
    //    Console.WriteLine($"{Title} - {Content}: {Author}");
    //}
}