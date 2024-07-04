internal class Program
{
    static void Main()
    {
        string[] daysOfWeek = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        int day = int.Parse(Console.ReadLine());

        if (day <= 7 && day >= 1)
        {
            Console.WriteLine(daysOfWeek[day-1]);
        }
        else
        {
            Console.WriteLine("Invalid day!");
        }
    }
}