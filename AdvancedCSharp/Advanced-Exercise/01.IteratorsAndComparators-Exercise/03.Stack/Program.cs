namespace _03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.TrimEnd(','))
                    .ToArray();

                switch (command[0])
                {
                    case "Push":

                        int[] array = command[1..].Select(int.Parse).ToArray(); 

                        stack.Push(array);
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
