

int countTotalTickets = 0;
int countTotalStudents = 0;
int countTotalStandards = 0;
int countTotalKids = 0;

while (true)
{

    bool isFinished = false;
    string movieName = Console.ReadLine();

    if (movieName == "Finish")
    {
        Console.WriteLine($"Total tickets: {countTotalTickets}");
        Console.WriteLine($"{100.0 * countTotalStudents / countTotalTickets:f2}% student tickets.");
        Console.WriteLine($"{100.0 * countTotalStandards / countTotalTickets:f2}% standard tickets.");
        Console.WriteLine($"{100.0 * countTotalKids / countTotalTickets:f2}% kids tickets.");

        break;
    }
    int countStudent = 0;
    int countStandard = 0;
    int countKid = 0;

    int overallSeats = int.Parse(Console.ReadLine());

    while (true)
    {
        bool isEnded = false;
        string input = Console.ReadLine();

        if (countStudent + countKid + countStandard <= overallSeats)
        {
            switch (input)
            {
                case "student":
                    countStudent++;
                    break;
                case "standard":
                    countStandard++;
                    break;
                case "kid":
                    countKid++;
                    break;
                case "End":
                    isEnded = true;
                    break;
                case "Finish":
                    isFinished = true;
                    break;


            }
        }
        if (isEnded || isFinished || countStudent + countStandard + countKid == overallSeats)
        {
            countTotalTickets += countStudent + countKid + countStandard;

            countTotalStudents += countStudent;
            countTotalStandards += countStandard;
            countTotalKids += countKid;

            Console.WriteLine($"{movieName} - {100.0 * (countStudent + countStandard + countKid) / overallSeats:f2}% full.");
            break;
        }

    }
    if (isFinished)
    {
        Console.WriteLine($"Total tickets: {countTotalTickets}");
        Console.WriteLine($"{100.0 * countTotalStudents / countTotalTickets:f2}% student tickets.");
        Console.WriteLine($"{100.0 * countTotalStandards / countTotalTickets:f2}% standard tickets.");
        Console.WriteLine($"{100.0 * countTotalKids / countTotalTickets:f2}% kids tickets.");

        break;
    }
}