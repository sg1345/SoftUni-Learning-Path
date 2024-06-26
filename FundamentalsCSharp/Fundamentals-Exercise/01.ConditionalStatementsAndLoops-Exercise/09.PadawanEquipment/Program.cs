internal class Program
{
    static void Main()
    {
        var budget = double.Parse(Console.ReadLine());
        var students = int.Parse(Console.ReadLine());
        var priceLightsabers = double.Parse(Console.ReadLine());
        var priceRobes = double.Parse(Console.ReadLine());
        var priceBelts = double.Parse(Console.ReadLine());

        var lightsabers = (int)Math.Ceiling(students * 1.1); // 10% more 

        var robes = students;

        var belts = students - (students / 6); // every sixth belt is free.

        var total = lightsabers * priceLightsabers + robes * priceRobes + belts * priceBelts;

        var difference = total - budget;

        if (total > budget) 
        {
            Console.WriteLine($"John will need {Math.Abs(difference):f2}lv more.");
        }
        else
        {
            Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
        }
    }
}