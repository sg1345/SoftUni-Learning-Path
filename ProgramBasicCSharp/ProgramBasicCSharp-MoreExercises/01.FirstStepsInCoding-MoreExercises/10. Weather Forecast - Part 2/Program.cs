
//При въвеждане на температурата отвън трябва да принтира
//дали времето е: Hot, Warm, Mild, Cool, Cold.
//input
double degrees = double.Parse(Console.ReadLine());

//output
if (degrees >= 26 && degrees <= 35 )
{
    Console.WriteLine("Hot");
}else if (degrees >=20.1 && degrees <35)
{
    Console.WriteLine("Warm");

}else if(degrees >=15 && degrees <20.1)
{
    Console.WriteLine("Mild");

}else if((degrees >=12 && degrees <15))
{
    Console.WriteLine("Cool");

}else if (degrees >=5  && degrees <12)
{
    Console.WriteLine("Cold");

}else
{
    Console.WriteLine("unknown");

}
