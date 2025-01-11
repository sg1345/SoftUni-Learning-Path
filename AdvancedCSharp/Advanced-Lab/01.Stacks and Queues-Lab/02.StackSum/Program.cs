internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Stack<int> stack = new(numbers);

        string command = string.Empty;

        while((command = Console.ReadLine().ToLower()) != "end")
        {
            string[] token = command.Split();  

            switch(token[0])
            {
                case "add":
                    stack.Push(int.Parse(token[1]));
                    stack.Push(int.Parse(token[2]));
                    break;

                case "remove":

                    int countOfElementsToRemove = int.Parse(token[1]);

                    if(stack.Count < countOfElementsToRemove)
                    {
                        continue;
                    }

                    for (int i = 0; i < countOfElementsToRemove; i++)
                    {
                        stack.Pop();
                    }
                    break;
            }
        }

        Console.WriteLine($"Sum: {stack.ToArray().Sum()}");         
    }
}
