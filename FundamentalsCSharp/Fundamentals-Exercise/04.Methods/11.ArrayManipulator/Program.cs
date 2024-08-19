
using System.Linq.Expressions;

internal class Program
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        string input = "";

        while ((input=Console.ReadLine())!="end")
        {
            var command = input.Split();
                
            var count = 0;
            
            switch (command[0])
            {
                case "exchange":

                    var index = int.Parse(command[1]);

                    ExchangeIndex(index, array);

                    break;

                case "max":

                    MaxIndex(command[1], array);

                    break;

                case "min":

                    MinIndex(command[1], array);

                    break;

                case "first":

                    count = int.Parse(command[1]);

                    FirstNumberOfElements(count, command[2], array);

                    break;

                case "last":

                    count = int.Parse (command[1]);

                    LastNumberOfElements(count, command[2], array);

                    break;
            }
            
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }


    static void ExchangeIndex(int splitPoint, int[] array) // 2 , [1, 2, 3, 4, 5]
    {   
        if(splitPoint < 0 || splitPoint + 1 > array.Length)
        {
            Console.WriteLine("Invalid index");
            return;
        }

        var temp = new int[array.Length]; // 0 0 0 0 0
        var tempIndex = 0; // 0 

        for (int i = splitPoint + 1; i < array.Length; i++) // index = 3, 4 
        {
            temp[tempIndex++] = array[i]; // 4 5
        }

        for (int i = 0; i < splitPoint + 1; i++) // index = 0, 1, 2
        {
            temp[tempIndex++] = array[i]; // 4 5 1 2 3
        }
        
        for(int i = 0;i < array.Length; i++)
        {
            array[i] = temp[i];
        }

        //Console.WriteLine($"[{string.Join(" ", array)}]");

    }

    static void MaxIndex(string command, int[] array)
    {
        var maxNumber = int.MinValue;
        var maxIndex = -1;
        var isMatched = false;

        for (int i = 0; i < array.Length; i++)
        {
            if (CheckEven(command, array[i]))
            {
                if (maxNumber <= array[i])
                {
                    maxNumber = array[i];
                    isMatched = true;
                    maxIndex = i;
                }
            }
            else if (CheckOdd(command, array[i]))
            {
                if (maxNumber <= array[i])
                {
                    maxNumber = array[i];
                    isMatched = true;
                    maxIndex = i;
                }
            }
        }

        if (isMatched)
        {
            Console.WriteLine(maxIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
    
    static void MinIndex(string command, int[] array)
    {
        var minIndex = -1;
        var minNumber = int.MaxValue;
        var isMatched = false;

        for (int i = 0; i < array.Length; i++)
        {
            if (CheckEven(command, array[i]) && minNumber >= array[i])
            {           
                minNumber = array[i];
                isMatched = true;
                minIndex = i;
            }
            else if (CheckOdd(command, array[i]) && minNumber >= array[i])
            {
                minNumber = array[i];
                isMatched = true;
                minIndex = i;
            }
        }

        if (isMatched)
        {
            Console.WriteLine(minIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
    
    static void FirstNumberOfElements(int count, string command, int[] array) // 3, even, [1, 2, 3, 4, 5]
    {
        if (count > array.Length)
        {
            Console.WriteLine("Invalid count");
            return; 
        }
        var temp = new int[count]; //[0, 0, 0]
        var tempIndex = 0; 

        for (int i = 0; i < array.Length; i++)
        {            
            if (CheckEven(command, array[i]))
            {
                temp[tempIndex++] = array[i]; //temp = [2, 4, 0]
            }
            else if (CheckOdd(command, array[i]))
            {
                temp[tempIndex++] = array[i];
            }

            if (tempIndex == count) 
            {
                break;
            }

        }

        if (tempIndex != 0)
        {
            var print = "";

            Console.Write("[");
            for (int i = 0; i < tempIndex; i++)
            {
                print += $"{temp[i]}, ";
            }
            Console.Write(print.TrimEnd(' ',',') + "]");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("[]");
        }
    }
    
    static void LastNumberOfElements(int count, string command, int[] array) // 3, even, [1, 2, 3, 4, 5]
    {
        if (count > array.Length) // 3 > 5 - false
        {
            Console.WriteLine("Invalid count");
            return;
        }
        var temp = new int[count]; // [0, 0, 0]
        var tempIndex = count - 1; // 3
        
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (CheckEven(command, array[i]))
            {
                temp[tempIndex--] = array[i]; // temp = [0, 2, 4]
            }
            else if (CheckOdd(command, array[i]))
            {
                temp[tempIndex--] = array[i]; 
            }

            if (tempIndex == - 1)
            {
                break;
            }

        }

        if (tempIndex != count-1)
        {
            var print = "";

            Console.Write("[");
            for (int i = tempIndex + 1; i < temp.Length; i++)
            {
                print += $"{temp[i]}, ";
            }
            Console.Write(print.TrimEnd(' ', ',') + "]");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("[]");
        }

    }
    
    static bool CheckEven(string command, int number)
    {
        if (command == "even" && number % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    static bool CheckOdd(string command, int number)
    {
        if (command == "odd" && number % 2 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
