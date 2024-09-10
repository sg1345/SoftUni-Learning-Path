internal class Program
{
    static void Main()
    {
        List<string> list = Console.ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "3:1")
        {

            var command = input.Split();

            switch (command[0])
            {
                case "merge":

                    var startIndex = int.Parse(command[1]);
                    var endIndex = int.Parse(command[2]);

                    MergeElementsInList(startIndex, endIndex, list);  
                    break;

                case "divide":

                    var index = int.Parse(command[1]);
                    var numberOfParts = int.Parse(command[2]);

                    DivideElementsInList(index, numberOfParts, list);

                    break;
            }
        }

        PrintListOfStrings(list);
    }

    static void DivideElementsInList(int index, int numberOfParts, List<string> list) // 0, 3 , {1234567 1 1}
    {
        var element = list[index]; // element = 1234567
        list.RemoveAt(index); //  0 1
                              // {1 1}
        var stringLength = element.Length; // stringLength = 7

        var partLength = stringLength / numberOfParts; //partLength = 7/3 = 2

        var remeinder = stringLength % numberOfParts; // remeinder = 7 % 3 = 1

        var countdown = numberOfParts;
        var i = 0;
        var correctionIndex = 0;

        while (true) 
        {
            

                if (countdown != 1) //true // true // false
                {
                    string newPart = element.Substring(i, partLength); // 12 // 34
                    list.Insert(index + correctionIndex, newPart); //{12 1 1} // { 12 34 1 1}
                    correctionIndex++;
                }
                else
                {
                    string newPart = element.Substring(i, partLength + remeinder); // 567
                    list.Insert(index + correctionIndex, newPart); // {12 34 567 1 1}
                    correctionIndex++;
                }

            countdown--;// 1 // 2 // 3
            if (countdown == 0) // false // false // true
            {
                break;
            }
            i += partLength; // 2 // 4 
            
        }

    }
    static void MergeElementsInList(int startIndex, int endIndex, List<string> list)
    {
        startIndex = InRangeConverter(startIndex, list.Count - 1);
        endIndex = InRangeConverter(endIndex, list.Count - 1);
        

        var count = endIndex - startIndex + 1;

        var merged = string.Join("", list.GetRange(startIndex, count));
        list.RemoveRange(startIndex, count);
        list.Insert(startIndex, merged);
    }
    static int InRangeConverter(int index, int limit)
    {
        if (index < 0)
        {
            index = 0;
        }
        else if (index > limit)
        {
            index = limit;
        }

        return index;
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