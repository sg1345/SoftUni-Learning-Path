
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
char operation = char.Parse(Console.ReadLine());

double result = 0;
string parity = "";

switch (operation)
{
    case '+':
        result = number1 + number2;
        if (result % 2 == 0)
        {
            parity = "even";
        }
        else
        {
            parity = "odd";
        }
        break;
    case '-':
        result = number1 - number2;
        if (result % 2 == 0)
        {
            parity = "even";
        }
        else
        {
            parity = "odd";
        }
        break;
    case '*':
        result = number1 * number2;
        if (result % 2 == 0)
        {
            parity = "even";
        }
        else
        {
            parity = "odd";
        }
        break;
    case '/':
        if (number2 == 0)
        {

        }
        else
        {
        result = (double)number1 / number2;
        }
        break;
    case '%':
        if (number2 == 0)
        {

        }
        else
        {
            result = number1 % number2;
        }
        break;


}

if (operation == '+' || operation == '-' || operation == '*')
{
    Console.WriteLine($"{number1} {operation} {number2} = {result} - {parity}");
}
else if (operation == '/')
{
    if (number2 == 0)
    {
       Console.WriteLine($"Cannot divide {number1} by zero");
    }
    else
    {
        Console.WriteLine($"{number1} {operation} {number2} = {result:f2}");
    }
}
else if (operation == '%')
{
    if (number2 == 0)
    {
        Console.WriteLine($"Cannot divide {number1} by zero");
    }
    else
    {
        Console.WriteLine($"{number1} {operation} {number2} = {result}");
    }
}