internal class Program
{
    static void Main()
    {
        string message = Console.ReadLine();

        string input = string.Empty;
        while((input = Console.ReadLine()) != "Done")
        {
            string[] command = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            switch(command[0])
            {
                case "Change":
                    char  originalLetter = char.Parse(command[1]);
                    char newLetter = char.Parse(command[2]);

                    message = new string
                        (message.Select(letter => letter == originalLetter ? newLetter : letter).ToArray());

                    Console.WriteLine(message);
                    break;

                case "Includes":
                    
                    Console.WriteLine(message.Contains(command[1]));
                    break;

                case "End":                    

                    Console.WriteLine(message.EndsWith(command[1]));
                    break;

                case "Uppercase":
                    message = message.ToUpper();

                    Console.WriteLine(message);
                    break;
                case "FindIndex":
                    char letter = char.Parse(command[1]);
                    
                    Console.WriteLine(message.IndexOf(letter));
                    break;
                case "Cut":
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);
                    
                    message = message.Substring(startIndex, count);

                    Console.WriteLine(message);
                    break;
            }
        }
    }
}
