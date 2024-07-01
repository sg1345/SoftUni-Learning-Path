/*
1
1000
500
100

4
0
1
0
1000
1
100
11
3
3
10
3
3

*/


using System.Numerics;

internal class Program
{
    static void Main()
    {
        var numberOfSnowballs = int.Parse(Console.ReadLine());   // 0-100   

        var bestSnowballSnow = int.MinValue;
        var bestSnowballTime = int.MinValue;
        var bestSnowballQuality = int.MinValue;
        
        var bestSnowballValue = BigInteger.MinusOne;

        for (int i = 1; i <= numberOfSnowballs; i++)
        {
            var snowballSnow = int.Parse(Console.ReadLine());    // 0-1000
            var snowballTime = int.Parse(Console.ReadLine());    // 1-500
            var snowballQuality = int.Parse(Console.ReadLine()); // 0-100


         
            var snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

            if (bestSnowballValue <= snowballValue)
            {
                bestSnowballValue = snowballValue;
                bestSnowballQuality = snowballQuality;
                bestSnowballTime = snowballTime;
                bestSnowballSnow = snowballSnow;
            }
        }

        Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");
    }
}