
internal class Program
{
    static void Main()
    {
        decimal[] firstLine = new decimal[4];
        decimal[] secondLine = new decimal[4];

        ReadCoordinates(firstLine);
        ReadCoordinates(secondLine);

        decimal firstLineDistance = CalculateDistance(firstLine);
        decimal secondLineDistance = CalculateDistance(secondLine);

        string result = CompareLines(firstLineDistance, secondLineDistance);

        PrintLongestLine(firstLine, secondLine, result);
    }

    static void ReadCoordinates(decimal[] line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            line[i] = decimal.Parse(Console.ReadLine());
        }
    }

    static decimal CalculateDistance(decimal[] firstLine)
    {
        decimal dx = firstLine[0] - firstLine[2];
        decimal dy = firstLine[1] - firstLine[3];

        decimal sqrt = dx * dx + dy * dy;

        return (decimal)Math.Sqrt((double)sqrt);
    }

    static string CompareLines(decimal firstLine, decimal secondLine)
    {
        return firstLine >= secondLine ? "First Line" : "Second Line";
    }

    static void PrintLongestLine(decimal[] firstLine, decimal[] secondLine, string result)
    {
        if (result == "First Line")
        {
            decimal pointOne = CalculateDistanceToOrigin(firstLine[0], firstLine[1]);
            decimal pointTwo = CalculateDistanceToOrigin(firstLine[2], firstLine[3]);
            
            string closestPoint = CompareDistanceBetweenTwoPointsToOrigin(pointOne, pointTwo);

            Console.WriteLine(OrderPointsBasedOnOrigin(firstLine,closestPoint));

        }
        else if (result == "Second Line")
        {
            decimal pointOne = CalculateDistanceToOrigin(secondLine[0], secondLine[1]);
            decimal pointTwo = CalculateDistanceToOrigin(secondLine[2], secondLine[3]);

            string closestPoint = CompareDistanceBetweenTwoPointsToOrigin(pointOne, pointTwo);

            Console.WriteLine(OrderPointsBasedOnOrigin(secondLine, closestPoint));
        }
    }
   
    static decimal CalculateDistanceToOrigin(decimal x, decimal y)
    {
        x = Math.Abs(x);
        y = Math.Abs(y);
        return x + y;
    }

    static string CompareDistanceBetweenTwoPointsToOrigin(decimal firstDistance, decimal secondDistance)
    {        
        return firstDistance <= secondDistance ? "First Point" : "Second Point";
    }

    static string OrderPointsBasedOnOrigin(decimal[] line, string result)
    {
        if ( result == "First Point")
        {
            return $"({line[0]}, {line[1]})({line[2]}, {line[3]})";
        }
        return $"({line[2]}, {line[3]})({line[0]}, {line[1]})";
    }

}