
string typeMovie = Console.ReadLine();
int columns = int.Parse(Console.ReadLine());
int  rows = int.Parse(Console.ReadLine());  

double overallPrice = 0;

if (typeMovie == "Premiere")
{
    overallPrice = columns * rows * 12.00;
}
else if (typeMovie == "Normal")
{
    overallPrice = columns * rows * 7.50;

}
else if (typeMovie == "Discount")
{
    overallPrice = columns * rows * 5.00;

}
Console.WriteLine($"{overallPrice:f2} leva");