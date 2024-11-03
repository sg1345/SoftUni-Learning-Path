internal class Program
{
    static void Main()
    {
        List <string> list = new();
        string text = "bbb aaa ccc kkk";
        list = text.Split(' ').ToList();

        foreach (string s in list.OrderBy(x => x))
        {
            Console.WriteLine(s);
        }
    }
}
