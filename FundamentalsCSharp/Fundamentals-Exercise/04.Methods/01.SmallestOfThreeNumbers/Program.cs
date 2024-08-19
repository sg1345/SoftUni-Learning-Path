internal class Program
{
    static void Main()
    {
        var firstInt = int.Parse(Console.ReadLine());
        var secondInt = int.Parse(Console.ReadLine());
        var thirdInt = int.Parse(Console.ReadLine());

        SmallestOfThreeNumbers(firstInt, secondInt, thirdInt);
    }

    static void SmallestOfThreeNumbers(int firstInt, int secondInt, int thirdInt)
    {
        if(firstInt < secondInt && firstInt < thirdInt) 
        {
            Console.WriteLine(firstInt);
        }
        else if (secondInt < thirdInt)  
        {
            Console.WriteLine(secondInt);
        }
        else
        {
            Console.WriteLine(thirdInt);
        }
    }
}

