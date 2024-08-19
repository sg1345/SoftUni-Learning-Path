
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        var password = Console.ReadLine();

        if (CheckPasswordLength(password) == false)
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }

        if (CheckLettersAndNumbersOnlyConsist(password) == false)
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }

        if (CountDigits(password) < 2) 
        {
            Console.WriteLine("Password must have at least 2 digits");
        }

        if (CheckPasswordLength(password) 
            && CheckLettersAndNumbersOnlyConsist(password) 
            && CountDigits(password) >=2 )
        {
            Console.WriteLine("Password is valid");
        }

    }

    static bool CheckPasswordLength(string password)
    {
        var isCorrectLength = true;

        if (password.Length > 10 || password.Length < 6)
        {
            isCorrectLength = false;
        }
        return isCorrectLength;
    }
    static bool CheckLettersAndNumbersOnlyConsist(string password)
    {
        var hasOnlyDigitsAndLetters = true;

        if (!password.All(Char.IsLetterOrDigit))
        {
            hasOnlyDigitsAndLetters = false;
        }

        return hasOnlyDigitsAndLetters;
    }
    static int CountDigits(string password)
    {
        var count = 0;
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i].ToString().All(Char.IsDigit))
            {
                count++;
            }
        }
        return count;
    }
}
