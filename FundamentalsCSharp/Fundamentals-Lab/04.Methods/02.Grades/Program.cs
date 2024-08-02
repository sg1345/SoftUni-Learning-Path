
internal class Program
{
    static void Main()
    {
        var grade = double.Parse(Console.ReadLine());

        PrintGrade(grade);
    }

    static void PrintGrade(double grade)
    {
        switch (grade)
        {
            case >= 2.00 and <= 2.99:
                Console.WriteLine("Fail");
                break;
            case >= 3.00 and <= 3.49:
                Console.WriteLine("Poor");
                break;
            case >= 3.50 and <= 4.49:
                Console.WriteLine("Good");
                break;
            case >= 4.50 and <= 5.49:
                Console.WriteLine("Very good");
                break;
            case >= 5.50 and <= 6.00:
                Console.WriteLine("Excellent");
                break;
        }
    }
}