
internal class Program
{
    static void Main()
    {
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());
        var area = GetRectagleArea(width, height);
        Console.WriteLine(area);
    }

    static double GetRectagleArea(double width, double height)
    {
        return width * height;
    }
}