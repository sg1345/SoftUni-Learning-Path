//input
int volumePool = int.Parse(Console.ReadLine());
int flowPipe1 = int.Parse(Console.ReadLine());
int flowPipe2 = int.Parse(Console.ReadLine());
double hoursMissing = double.Parse(Console.ReadLine());

//calculations
double volumeFromPipe1 = flowPipe1 * hoursMissing;
double volumeFromPipe2 = flowPipe2 * hoursMissing;

double percentageFull = ((volumeFromPipe1 + volumeFromPipe2) / volumePool)*100;
double overflowed = Math.Abs(volumeFromPipe1 + volumeFromPipe2- volumePool);

double percentageFromPipe1 = (volumeFromPipe1 / (volumeFromPipe1 + volumeFromPipe2))*100;
double percentageFromPipe2 = (volumeFromPipe2 / (volumeFromPipe2 + volumeFromPipe1))*100;


//output
if (volumePool >= (volumeFromPipe2 + volumeFromPipe1))
{
    Console.WriteLine($"The pool is {percentageFull:F2}% full. Pipe 1: {percentageFromPipe1:F2}%. Pipe 2: {percentageFromPipe2:F2}%.");
}
else
{
    Console.WriteLine($"For {hoursMissing:F2} hours the pool overflows with {overflowed:F2} liters.");
}