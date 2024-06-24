//input
double worldRecord = double.Parse(Console.ReadLine());
double distance = double.Parse(Console.ReadLine());
double speed = double.Parse(Console.ReadLine());

//calculations
double timeIvan = distance * speed;
double delay = Math.Floor(distance / 15) * 12.5;
double totalTime = timeIvan + delay;
double difference = Math.Abs(totalTime - worldRecord);

if(totalTime < worldRecord)
{
    Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
}
else
{
    Console.WriteLine($"No, he failed! He was {difference:F2} seconds slower.");
}
