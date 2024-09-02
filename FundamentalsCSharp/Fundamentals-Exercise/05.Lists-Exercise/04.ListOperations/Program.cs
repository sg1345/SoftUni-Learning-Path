using System.ComponentModel;

internal class Program
{
    static void Main()
    {
        List<int> list = ReadListOfIntegers();

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var command = input.Split();

            switch (command[0])
            {
                case "Add":  
                    
                    var number = int.Parse(command[1]);

                    list.Add(number);
                    break;

                case "Insert":

                    number = int.Parse(command[1]);
                    var index = int.Parse(command[2]);

                    if(IsNotInRange(index, list.Count))
                    {
                        ErrorMessage();
                        continue;
                    }

                    list.Insert(index, number);
                    break;

                case "Remove":

                    index = int.Parse(command[1]);

                    if (IsNotInRange(index, list.Count))
                    {
                        ErrorMessage();
                        continue;
                    }

                    list. RemoveAt(index);
                    break;

                case "Shift":

                    var direction = command[1];
                    var count = int.Parse(command[2]);               

                    list = ShiftNumbers(direction, count, list);
                    break;
            }
        }

        PrintListOfIntegers(list);
    }

    static bool IsNotInRange(int index , int arrayLength)
    {
        if (0 > index || index > arrayLength - 1)
        {
            return true;
        }

        return false;
    }
    private static void ErrorMessage()
    {
        Console.WriteLine("Invalid index");
    }
    static List<int> ShiftNumbers(string direction, int count, List<int> list)
    {
        count %= list.Count;

        switch (direction)
        {
            case "left":
                var array = new int[count];

                list.CopyTo(0,array,0,count);             
                list.RemoveRange(0, count);
                list.AddRange(array);    
                
                break;
            case "right":
                
                array = new int[list.Count];

                list.CopyTo(list.Count - count, array, 0, count);
                list.CopyTo(0, array, count, list.Count - count);
                list.Clear();
                list.AddRange(array);

                break;
        }
        return list;
    }

    static List<int> ReadListOfIntegers(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(int.Parse).ToList();
    }
    static List<double> ReadListOfDoubles(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(double.Parse).ToList();
    }
    static List<String> ReadListOfStrings(string separator = " ")
    {
        return Console.ReadLine().Split(separator).ToList();
    }

    static void PrintListOfIntegers(List<int> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfDoubles(List<double> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfStrings(List<string> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintArrayOfIntegers(int[] array, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, array));
    }
}