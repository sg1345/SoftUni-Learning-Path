
internal class Program
{
    static void Main(string[] args)
    {
        decimal x1 = decimal.Parse(Console.ReadLine());
        decimal y1 = decimal.Parse(Console.ReadLine());
        decimal x2 = decimal.Parse(Console.ReadLine());
        decimal y2 = decimal.Parse(Console.ReadLine());

        decimal firstDistance = CalculateDistance(x1, y1);
        decimal secondDistance = CalculateDistance(x2, y2);

        int closestToZero = ClosestDistance(firstDistance, secondDistance);

        PrintClossestDistance(x1, y1, x2, y2, closestToZero);
    }

    static decimal CalculateDistance(decimal x, decimal y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        return x + y;
    }
    
    static int ClosestDistance(decimal firstDistance, decimal secondDistance)
    {
        int closerDistance = firstDistance <= secondDistance ? 1 : 2;
        return closerDistance;
    }
    
    static void PrintClossestDistance(decimal x1, decimal y1, decimal x2, decimal y2, int closestToZero)
    {
        if (closestToZero == 1)
        {
            Console.WriteLine($"({x1}, {y1})");
        }
        else if (closestToZero == 2)
        {
            Console.WriteLine($"({x2}, {y2})");
        }
    }
}

