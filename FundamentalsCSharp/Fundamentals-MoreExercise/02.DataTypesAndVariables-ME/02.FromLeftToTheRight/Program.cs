using System.Numerics;

internal class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {            
            string input = Console.ReadLine();
            int spaceChar = input.IndexOf(' ');

            string firstHalf = input.Substring(0, spaceChar);
            string secondHalf = input.Substring(spaceChar + 1);         



            decimal firstNumber = decimal.Parse(firstHalf);
            decimal secondNumber = decimal.Parse(secondHalf);

            long result = 0;
            if (firstNumber >= secondNumber)
            {
                string minus = "-";
                firstHalf = firstHalf.Replace(minus, string.Empty);
                string floatingPoint = ".";
                firstHalf = firstHalf.Replace(floatingPoint, string.Empty);
                
                for (int j = 0; j < firstHalf.Length; j++)
                {
                    result += (firstHalf[j] - 48);
                }
            }
            else
            {
                string minus = "-";
                firstHalf = firstHalf.Replace(minus, string.Empty);
                string floatingPoint = ".";
                firstHalf = firstHalf.Replace(floatingPoint, string.Empty);

                for (int j = 0; j < secondHalf.Length; j++)
                {
                    result += (secondHalf[j] - 48);
                }
            }

            Console.WriteLine(result);
        }
    }
}