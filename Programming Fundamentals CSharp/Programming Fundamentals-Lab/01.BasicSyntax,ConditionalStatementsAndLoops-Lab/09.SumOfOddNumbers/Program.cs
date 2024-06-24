namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine(i*2-1);
                //Console.WriteLine(1+i*2);  
                sum += i*2-1;
                
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
