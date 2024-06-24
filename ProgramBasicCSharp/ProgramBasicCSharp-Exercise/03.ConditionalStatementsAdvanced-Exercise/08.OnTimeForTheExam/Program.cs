
int hourExam = int.Parse(Console.ReadLine());
int minutesExam = int.Parse(Console.ReadLine());
int hourArrival  = int.Parse(Console.ReadLine());
int minutesArrival  = int.Parse(Console.ReadLine());

int overallMinutesExam = hourExam * 60 + minutesExam;
int overallMinutesArrival = hourArrival * 60 + minutesArrival;

int hourDifferential = 0;
int minutesDifferential = 0;
string textMessage = ""; //Late, Early, On time
string beforeOrAfterText = "";
string minutesOrHoursText = "";

if (overallMinutesExam < overallMinutesArrival)
{
    hourDifferential = Math.Abs(overallMinutesArrival - overallMinutesExam) / 60;
    minutesDifferential = Math.Abs(overallMinutesArrival - overallMinutesExam) % 60;
    
    textMessage = "Late";
    beforeOrAfterText = "after";
    
    if (hourDifferential > 0)
    {
        minutesOrHoursText = "hours";
        Console.WriteLine($"{textMessage}");
        Console.WriteLine($"{hourDifferential}:{minutesDifferential:d2} {minutesOrHoursText} {beforeOrAfterText} the start");
    }
    else if (hourDifferential == 0)
    {
        minutesOrHoursText = "minutes";
        Console.WriteLine($"{textMessage}");
        Console.WriteLine($"{minutesDifferential} {minutesOrHoursText} {beforeOrAfterText} the start");
    }
} else if (overallMinutesExam-overallMinutesArrival <= 30)
{
    minutesDifferential = Math.Abs(overallMinutesArrival - overallMinutesExam) % 60;

    textMessage = "On time";
    beforeOrAfterText = "before";

    if (overallMinutesExam != overallMinutesArrival)
    {
        minutesOrHoursText = "minutes";
        Console.WriteLine($"{textMessage}");
        Console.WriteLine($"{minutesDifferential} {minutesOrHoursText} {beforeOrAfterText} the start");
    }
    else if (overallMinutesExam == overallMinutesArrival)
    {
    Console.WriteLine($"{textMessage}");
    }
}
else if (overallMinutesExam > overallMinutesArrival)
{
    hourDifferential = Math.Abs(overallMinutesArrival - overallMinutesExam) / 60;
    minutesDifferential = Math.Abs(overallMinutesArrival - overallMinutesExam) % 60;

    textMessage = "Early";
    beforeOrAfterText = "before";

    if (hourDifferential > 0)
    {
        minutesOrHoursText = "hours";
        Console.WriteLine($"{textMessage}");
        Console.WriteLine($"{hourDifferential}:{minutesDifferential:d2} {minutesOrHoursText} {beforeOrAfterText} the start");
    }
    else if (hourDifferential == 0)
    {
        minutesOrHoursText = "minutes";
        Console.WriteLine($"{textMessage}");
        Console.WriteLine($"{minutesDifferential} {minutesOrHoursText} {beforeOrAfterText} the start");
    }
}