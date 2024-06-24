
int number  = int.Parse(Console.ReadLine());
    
int sum = 0;

while (true)
{
    int numberToSum = int.Parse(Console.ReadLine());

    sum += numberToSum;
    if(sum >= number)
    {
        Console.WriteLine(sum);
        break;
    }

}