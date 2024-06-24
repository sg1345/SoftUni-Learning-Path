namespace _11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var times = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{number} X {times} = {number * times}");
                times++;
            } while (times <= 10);
            /*            var result = 0;
                        if (times > 10)
                        {
                            result = times * number;
                            Console.WriteLine($"{number} X {times} = {result}");
                        }
                        else
                        {
                            for (var i = times; i <= 10; i++)
                            {
                                result = number * i;
                                Console.WriteLine($"{number} X {i} = {result}");
                            }
                        }*/
        }
    }
}
