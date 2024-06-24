//input
string nameTVseries = Console.ReadLine();
int episodeDuration = int.Parse(Console.ReadLine());
int breakTime  = int.Parse(Console.ReadLine());

//calculations
double lunchTime = breakTime / 8.0;
double freeTime = breakTime / 4.0;

double timeNeeded = episodeDuration + lunchTime + freeTime;
double difference = Math.Abs(timeNeeded - breakTime);

//output
if (timeNeeded <= breakTime)
{
    Console.WriteLine($"You have enough time to watch {nameTVseries} and left with {Math.Ceiling(difference)} minutes free time.");
}
else
{
    Console.WriteLine($"You don't have enough time to watch {nameTVseries}, you need {Math.Ceiling(difference)} more minutes.");
}
