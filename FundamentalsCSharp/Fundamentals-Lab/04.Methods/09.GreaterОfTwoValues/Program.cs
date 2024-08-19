
internal class Program
{
    static void Main()
    {
        var inputType = Console.ReadLine();
        var firstInput = Console.ReadLine();
        var secondInput = Console.ReadLine();

        if (inputType == "int")
        {
            int firstNumber = int.Parse(firstInput);
            int secondNumber = int.Parse(secondInput);
            Console.WriteLine(GetMax(firstNumber, secondNumber));         
        }
        else if (inputType == "char")
        {
            char firstChar = char.Parse(firstInput);
            char secondChar = char.Parse(secondInput);
            Console.WriteLine(GetMax(firstChar, secondChar));
        }
        else
        {
            Console.WriteLine(GetMax(firstInput,secondInput));
        }

    }

    static int GetMax(int firstInput, int secondInput)
    {
        if (firstInput > secondInput) 
        {
            return firstInput;    
        }
        else 
        {
            return secondInput;
        }
    }
    static string GetMax(string firstInput, string secondInput)
    {
        var result = string.Compare(firstInput, secondInput);

        if (result < 0)
        {
            return secondInput;
        }
        else
        {
            return firstInput;
        }
    }
    static char GetMax(char firstInput, char secondInput)
    {
        if (firstInput > secondInput)
        {
            return firstInput;
        }
        else
        {
            return secondInput;
        }
    }
}