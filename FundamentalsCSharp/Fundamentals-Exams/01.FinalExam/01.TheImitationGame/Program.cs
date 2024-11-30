internal class Program
{
    static void Main()
    {
        string message = Console.ReadLine();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Decode")
        {
            string[] command = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

            switch (command[0])
            {
                case "Move":
                    int countLetters = int.Parse(command[1]);
                    message = message.Substring(countLetters) + message.Substring(0, countLetters);
                    break;

                case "Insert":
                    int index = int.Parse(command[1]);
                    message = message.Insert(index, command[2]);
                    break;

                case "ChangeAll":
                    char OriginalLetter = char.Parse(command[1]);
                    char newLetter = char.Parse(command[2]);
                    message = new string(message.
                        Select(letter => (letter == OriginalLetter ? newLetter : letter)).
                        ToArray());
                    break;
            }
        }
        Console.WriteLine($"The decrypted message is: {message}");
    }
}