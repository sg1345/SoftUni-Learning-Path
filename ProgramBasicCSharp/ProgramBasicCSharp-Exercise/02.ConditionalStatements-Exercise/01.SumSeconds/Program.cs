//input
int timeAthlete1 = int.Parse(Console.ReadLine());
int timeAthlete2 = int.Parse(Console.ReadLine());
int timeAthlete3 = int.Parse(Console.ReadLine());

//calculations

int sumTime = timeAthlete3 + timeAthlete2 + timeAthlete1;
int minutes = sumTime/ 60;
int seconds = sumTime % 60;

//output
Console.WriteLine($"{minutes}:{seconds:D2}");

//Решението с if е:
/*
if (seconds < 10) 
{   
    Console.WriteLine($"{minutes}:0{seconds}");
}
else
{
    Console.WriteLine($"{minutes}:{seconds}");
}
*/
