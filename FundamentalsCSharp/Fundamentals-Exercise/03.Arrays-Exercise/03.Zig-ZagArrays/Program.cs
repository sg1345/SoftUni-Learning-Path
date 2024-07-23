internal class Program
{
    static void Main()
    {
        var arrayLength = int.Parse(Console.ReadLine()); //4

        string[] firstArray = new string[arrayLength];
        string[] secondArray = new string[arrayLength];

        for (int i = 1; i <= arrayLength; i++) // 1 | 2 |
        {
            string[] elements = Console.ReadLine()
                .Split(); //  1 5 | 9 10 |

            if (i%2 != 0) // true |
            {
                firstArray[i - 1] = elements[0]; // 1
                secondArray[i - 1] = elements[1]; // 5
            }
            else
            {
                firstArray[i - 1] = elements[1]; // 10
                secondArray[i - 1] = elements[0]; // 9
            }
        }

        Console.WriteLine(string.Join(" ",firstArray));
        Console.WriteLine(string.Join(" ",secondArray));
    }
}