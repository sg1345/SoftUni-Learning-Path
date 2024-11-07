internal class Program
{
    static void Main()
    {
        Article arcticle = new();

        arcticle.Title = new();
        arcticle.Content = new();
        arcticle.Author = new();

        int numberOfEdits = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEdits; i++)
        {
            string[] input = Console.ReadLine().Split(',').Select(s => s.Trim()).ToArray();

            arcticle.Title.Add(input[0]);
            arcticle.Content.Add(input[1]);
            arcticle.Author.Add(input[2]);

            Console.WriteLine(arcticle);
        }
    }
}
class Article
{
    public override string ToString()
    {
        int i = Title.Count - 1;

        return $"{Title[i]} - {Content[i]}: {Author[i]}";
    }

    public List<string> Title { get; set; }
    public List<string> Content { get; set; }
    public List<string> Author { get; set; }
}