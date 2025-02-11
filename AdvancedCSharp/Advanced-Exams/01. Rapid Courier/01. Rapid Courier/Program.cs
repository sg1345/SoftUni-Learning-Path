namespace _01._Rapid_Courier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] packagesCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> packages = new Stack<int>(packagesCapacity);

            int[] couriersCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> couriers = new Queue<int>(couriersCapacity);

            int totalWeight = 0;

            while (packages.Count != 0 && couriers.Count != 0)
            {
                int package = packages.Pop();
                int courier = couriers.Dequeue();

                if (package == courier)
                {
                    totalWeight += package;                    
                }
                else if (package < courier)
                {
                    courier -= package * 2;
                    totalWeight += package;
                    if (courier > 0)
                    {
                        couriers.Enqueue(courier);                        
                    }                   
                }
                else if (package > courier)
                {

                    package -= courier;
                    totalWeight += courier;
                    packages.Push(package);
                }
            }

            Console.WriteLine($"Total weight: {totalWeight} kg");

            if(packages.Count == 0 && couriers.Count == 0)
            {
                Console.WriteLine("Congratulations, " +
                    "all packages were delivered successfully by the couriers today.");
            }
            else if(packages.Count > 0)
            {
                Console.WriteLine($"Unfortunately," +
                    $" there are no more available couriers to deliver" +
                    $" the following packages: {string.Join(", ",packages)}");
            }
            else if(couriers.Count > 0)
            {
                Console.WriteLine($"Couriers are still on duty:" +
                    $" {string.Join(", ",couriers)} but there are no more" +
                    $" packages to deliver.");
            }
        }
    }
}