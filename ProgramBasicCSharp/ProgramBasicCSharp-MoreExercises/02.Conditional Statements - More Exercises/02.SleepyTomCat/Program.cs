//input
int  freeDays = int.Parse(Console.ReadLine());

//calculations

int minuteToPlayFreeDays = freeDays * 127;
int workDays = 365 - freeDays;
int minutesToPlayWorkDays = workDays * 63;
int minutesForPlayPerYear = 30000 - minuteToPlayFreeDays -  minutesToPlayWorkDays;

int hours = Math.Abs(minutesForPlayPerYear / 60);
int minutes = Math.Abs(minutesForPlayPerYear % 60);

//output
if (minutesForPlayPerYear < 0)
{

    Console.WriteLine("Tom will run away");
    Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
}
else
{
    Console.WriteLine("Tom sleeps well");
    Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
}