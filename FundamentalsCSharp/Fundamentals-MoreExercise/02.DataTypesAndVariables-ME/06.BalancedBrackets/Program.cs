internal class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        bool isClossed = false;
        bool isOpened = false;
        bool error = false;
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine().Trim();
            
            if (input == "(" && isOpened)
            {
                error = true;
            }
            else if (input == "(")
            {
                isOpened = true;
            }
            

            if (input == ")" && isOpened)
            {
                isClossed = true;
            }
            else if (input == ")" && !isOpened)
            {
                error = true;
            }

            if (isClossed && isOpened && !error)
            {
                isClossed = false;
                isOpened = false;
            }
        }
        if (!isClossed && !isOpened && !error)
        {
            Console.WriteLine("BALANCED");
        }
        else
        {
            Console.WriteLine("UNBALANCED");
        }
    }
}