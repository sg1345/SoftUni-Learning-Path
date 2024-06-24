
double neededMoney = double.Parse(Console.ReadLine());
double moneyOnHand  = double.Parse(Console.ReadLine());

int countDays = 0;
int countDaysSpend = 0;

while (neededMoney > moneyOnHand)
{
    string spendOrSave = Console.ReadLine();

    double amount = double.Parse(Console.ReadLine());
   
    countDays++;

    if (spendOrSave == "spend")
    {
        moneyOnHand -= amount;
        countDaysSpend++;

        if (moneyOnHand < 0)
        {
            moneyOnHand = 0;
        }
        if (countDaysSpend == 5)
        {
            break;
        }
    }
    else if (spendOrSave == "save")
    {
        moneyOnHand += amount;
        countDaysSpend = 0;
    }
}

if (neededMoney <= moneyOnHand)
{
    Console.WriteLine($"You saved the money for {countDays} days.");
}
else
{
    Console.WriteLine("You can't save the money.");
    Console.WriteLine(countDays);
}