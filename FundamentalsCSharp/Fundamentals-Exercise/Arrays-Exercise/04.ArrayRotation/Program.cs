internal class Program
{
    static void Main()
    {
        string[] initialArray = Console.ReadLine()
            .Split(); // 51 47 32 61 21 
        var timesOfRotations = int.Parse(Console.ReadLine()); //2

        string[] newArray = new string[initialArray.Length];

        var countRotarions = 0;

        for (int i = 0; i < initialArray.Length; i++) // 0 // 1 // 2 
        {
            if (timesOfRotations > initialArray.Length)
            {
                timesOfRotations -= initialArray.Length;
            }
            if (timesOfRotations != 0) // 2 // 1 // 0
            {
                // newArray[3] = initialArray[0] // newArray [4] = initialArray[1]
                newArray[initialArray.Length-timesOfRotations] = initialArray[i];
                timesOfRotations--; // 1 // 0
                countRotarions++;
            }
            else
            {
                // newArray[0] = initialArray[2] //
                newArray[i - countRotarions] = initialArray[i];   
            }
        }

        Console.WriteLine(string.Join(" ",newArray));
    }
}