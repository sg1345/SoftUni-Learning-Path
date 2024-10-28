internal class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        string text = Console.ReadLine();

        string result = string.Empty;


        for (int i = 0; i < input.Length; i++)
        {
            int sumOfDigits = 0;
            string currentNumber = input[i];

            for (int j = 0; j < currentNumber.Length; j++)
            {
                int currentDigit = int.Parse(currentNumber[j].ToString());

                sumOfDigits += currentDigit;
            }

            if (sumOfDigits > text.Length)
            {
                sumOfDigits %= (text.Length);
            }

            result += text[sumOfDigits];
            text = text.Remove(sumOfDigits, 1);
            sumOfDigits -= 1;
        }

        Console.WriteLine(result);
    }
}

