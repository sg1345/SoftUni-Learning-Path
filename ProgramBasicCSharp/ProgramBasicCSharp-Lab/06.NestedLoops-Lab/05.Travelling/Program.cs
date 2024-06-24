

double neededMoney = 0;

double savedMoney = 0.0;


while (true)
{
   string input = Console.ReadLine();

    if (input == "End")
    {
        break;
    }
       neededMoney = double.Parse(Console.ReadLine());
    

    while (true)
    {
        if (neededMoney <= savedMoney)
        {
            Console.WriteLine($"Going to {input}!");
            savedMoney = 0;
            break;
        }
        
        double addMoney = double.Parse(Console.ReadLine());
        savedMoney += addMoney;
    }

}