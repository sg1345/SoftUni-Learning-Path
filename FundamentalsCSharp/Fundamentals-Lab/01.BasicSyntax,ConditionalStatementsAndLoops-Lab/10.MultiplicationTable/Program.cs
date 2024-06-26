namespace _10.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var number = int.Parse(Console.ReadLine());
            var times = 1;

            while (times <= 10)
            {
                Console.WriteLine($"{number} X {times} = {number * times}");
                times++;
            }
/*            var result = 0;
            for (int i = 1; i <= 10; i++)
            {
                result = number * i;
                Console.WriteLine($"{number} X {i} = {result}");
            }*/
        }
    }
}
