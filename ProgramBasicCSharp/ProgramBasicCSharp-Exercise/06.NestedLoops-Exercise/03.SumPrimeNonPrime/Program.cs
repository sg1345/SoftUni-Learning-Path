
//string input = Console.ReadLine();

int sumPrime = 0;
int sumNonPrime = 0;


while (true)
{
    bool isNegative = false;
    bool isPrime = true;
    
    string input = Console.ReadLine();

    if (input == "stop")
    {
        break;
    }
    int number = int.Parse(input);

    if (number < 0)
    {
        isNegative = true;  //негативно число
    }
    else if (number == 0 || number == 1)
    {
        sumNonPrime += number;  //за нула нищо
    } 
    else if (number > 1)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                sumNonPrime += number;  //непросто число
                break;
            }
        }
        if (isPrime)
        {
            sumPrime += number;
        }
    }
    if (isNegative)
    {
        Console.WriteLine("Number is negative.");
    }
}


Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");