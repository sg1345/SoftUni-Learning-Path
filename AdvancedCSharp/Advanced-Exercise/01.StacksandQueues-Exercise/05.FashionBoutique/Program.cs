internal class Program
{
    static void Main()
    {
        Stack<int> stack = new(Console.ReadLine().Split().Select(int.Parse));
        int rackCapacity = int.Parse(Console.ReadLine());

        int countRacks = 1;
        int currentRackCapacity = rackCapacity;
        while (stack.Count > 0)
        {
            if (currentRackCapacity < stack.Peek())
            {
                currentRackCapacity = rackCapacity;
                countRacks++;
            }

            if (currentRackCapacity >= stack.Peek())
            {
                currentRackCapacity -= stack.Pop();
            }
        }

        Console.WriteLine(countRacks);
    }
}