using System.Numerics;
using System.Xml;

internal class Program
{
    static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string dataType =string.Empty;
            if (int.TryParse(input, out int valueInt))
            {
                dataType = "integer";
                Console.WriteLine($"{input} is {dataType} type");

            }
            else if (double.TryParse(input, out double valueDouble))
            {
                dataType = "floating point";
                Console.WriteLine($"{input} is {dataType} type");

            }
            else if (char.TryParse(input, out char valueChar))
            {
                dataType = "character";
                Console.WriteLine($"{input} is {dataType} type");

            }
            else if (bool.TryParse(input, out bool valueBool))
            {
                dataType = "boolean";
                Console.WriteLine($"{input} is {dataType} type");

            }
            else
            {
                dataType = "string";
                Console.WriteLine($"{input} is {dataType} type");
            }
        }
    }
}