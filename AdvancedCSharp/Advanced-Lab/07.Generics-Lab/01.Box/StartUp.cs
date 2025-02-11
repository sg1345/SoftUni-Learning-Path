namespace BoxOfT
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new();
            box.Add(1);
            box.Add(1);
            box.Add(1);
            box.Add(1);

            Console.WriteLine(box.Count);
        }
    }
}
