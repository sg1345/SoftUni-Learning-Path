
int number = int.Parse(Console.ReadLine());

//Ако не знаеш, че Math.Pow е степенуване
int result = 1;

for (int i = 0; i <= number; i++)
{
    result *= 2;

    if (i % 2 == 0)
    {
        Console.WriteLine(Math.Abs(result / 2));
    }
}
//Ако знаеш, че Math.Pow е степенуване
//for (int i = 0; i < number; i+=2)
//{
//    Console.WriteLine(Math.Pow(2,i));
//}