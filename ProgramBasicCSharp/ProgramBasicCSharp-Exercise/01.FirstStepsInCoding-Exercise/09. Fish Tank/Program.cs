//input
int length = int.Parse(Console.ReadLine());
int width = int.Parse(Console.ReadLine());
int hеight = int.Parse(Console.ReadLine());
double percentOfTakenSpace = double.Parse(Console.ReadLine());

//calculations
double volumeOfTank = length * width * hеight * 0.001;
double spaceForWater = volumeOfTank * (1 - percentOfTakenSpace * 0.01);

//output
Console.WriteLine(spaceForWater);