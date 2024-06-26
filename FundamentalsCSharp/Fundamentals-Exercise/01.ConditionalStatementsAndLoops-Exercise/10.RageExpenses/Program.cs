internal class Program
{
    static void Main()
    {
        var lostGames = int.Parse(Console.ReadLine());
        var headsetPrice = double.Parse(Console.ReadLine());
        var mousePrice = double.Parse(Console.ReadLine());
        var keyboardPrice = double.Parse(Console.ReadLine());
        var displayPrice = double.Parse(Console.ReadLine());

        var rageExpenses = 0.0;

        var keyboardTrashCount = 0;

        for (int i = 1; i <= lostGames; i++) 
        {
           
            if (i % 2== 0)
            {
                rageExpenses += headsetPrice;
            }

            if (i % 3 == 0)
            {
                rageExpenses += mousePrice;
            }

            if (i % 2 == 0 && i % 3 == 0) 
            {
                rageExpenses += keyboardPrice;
                keyboardTrashCount++;
            }

            if (keyboardTrashCount % 2 == 0 && keyboardTrashCount !=0)
            {
                rageExpenses += displayPrice;
                keyboardTrashCount = 0;
            }
        }

        Console.WriteLine($"Rage expenses: {rageExpenses:F2} lv.");
    }
}