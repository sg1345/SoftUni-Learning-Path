internal class Program
{
    static void Main()
    {
        double neededMoney = double.Parse(Console.ReadLine());
        int months = int.Parse(Console.ReadLine());

        double savedMoney = 0;
        for (int i = 1; i <= months; i++)
        {
            if (i == 1)
            {
                savedMoney += neededMoney * 0.25;
                continue;
            }

            if (i % 2 == 1)
            {
                savedMoney -= savedMoney * 0.16;
            }

            if (i % 4 == 0)
            {
                savedMoney += savedMoney * 0.25;
            }

            savedMoney += neededMoney * 0.25;
        }

        double money = Math.Abs(savedMoney-neededMoney);

        if (savedMoney >= neededMoney)
        {
            Console.WriteLine($"Bravo! You can go to Disneyland and you will have {money:f2}lv. for souvenirs.");
        }
        else
        {
            Console.WriteLine($"Sorry. You need {money:f2}lv. more.");
        }
    }
}