
internal class Program
{
    static void Main()
    {
        string varType = Console.ReadLine();
        string input = Console.ReadLine();

        switch (varType)
        {
            case "int":
                int resultInt = int.Parse(input);
                PrintResult(resultInt);
                break;
            case "real":
                double resultDouble = double.Parse(input);
                PrintResult(resultDouble);
                break;
            case "string":
                string resultString = input;
                PrintResult(resultString);
                break;
        }
    }

    static void PrintResult(int input)
    {
        Console.WriteLine(input * 2);
    }

    static void PrintResult(double input)
    {
        Console.WriteLine($"{input*1.5:f2}");
    }

    static void PrintResult(string input)
    {
        Console.WriteLine($"${input}$");
    }
}

