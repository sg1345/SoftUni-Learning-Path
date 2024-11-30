using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string bigNumber = new string(input.Reverse().ToArray());


        int multiplier = int.Parse(Console.ReadLine());

        if (multiplier  == 0 )
        {
            Console.WriteLine("0");
            return;
        }

        string reversed = string.Empty;
        int additionalNumber = 0;
        foreach (char number in bigNumber)
        {
            string digit = number.ToString();
            int product = multiplier * int.Parse(digit) + additionalNumber;

            reversed += (product % 10).ToString();

            additionalNumber = product / 10;
        }

        if (additionalNumber != 0)
        {
            reversed += additionalNumber.ToString();
        }
        string result = new string(reversed.Reverse().ToArray());

        Console.WriteLine(result);
    }
}