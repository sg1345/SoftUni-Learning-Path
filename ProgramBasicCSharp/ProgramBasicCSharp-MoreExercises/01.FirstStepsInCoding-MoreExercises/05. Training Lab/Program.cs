double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());

int seatsPerColumn = (int)(100 * width - 100) / 70;
int seatsPerRow = (int)(100 * length) / 120;

int totalSeats = seatsPerColumn * seatsPerRow - 3;

Console.WriteLine(totalSeats);
