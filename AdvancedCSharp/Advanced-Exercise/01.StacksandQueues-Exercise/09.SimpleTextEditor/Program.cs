internal class Program
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();

        int countCommands = int.Parse(Console.ReadLine());
        string text = string.Empty;
        for (int i = 0; i < countCommands; i++)
        {
            string[] command = Console.ReadLine().Split();

            switch (command[0])
            {
                case "1":
                    text += command[1];
                    stack.Push(text);
                    break;

                case "2":
                    if (text.Length == int.Parse(command[1]))
                    {
                        text = string.Empty;
                        stack.Push(text);
                        continue;
                    }
                    int remainingLetters = text.Length - int.Parse(command[1]);

                    text = text.Substring(0, remainingLetters);
                    stack.Push(text);

                    break;

                case "3":
                    Console.WriteLine(text[int.Parse(command[1]) - 1]);
                    break;

                case "4":
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        text = string.Empty;
                        continue;
                    }
                    text = stack.Peek();
                    break;
            }
        }
    }
}