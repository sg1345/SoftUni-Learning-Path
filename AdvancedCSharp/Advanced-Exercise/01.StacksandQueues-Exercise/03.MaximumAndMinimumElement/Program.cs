internal class Program
{
    static void Main()
    {
        int countQueries = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();

        Stack<int> minNumbersStack = new Stack<int>();
        Stack<int> maxNumbersStack = new Stack<int>();

        int minNumber = 109;
        int maxNumber = 1;
        for (int i = 0; i < countQueries; i++)
        {
            int[] query = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            switch (query[0])
            {
                case 1:
                    stack.Push(query[1]);

                    if (minNumber > query[1])
                    {
                        minNumber = query[1];
                        minNumbersStack.Push(minNumber);
                    }

                    if (maxNumber < query[1])
                    {
                        maxNumber = query[1];
                        maxNumbersStack.Push(maxNumber);
                    }
                    break;

                case 2:

                    if (stack.Peek() == minNumbersStack.Peek())
                    {
                        minNumbersStack.Pop();

                        if (minNumbersStack.Count == 0)
                        {
                            minNumber = 109;                            
                        }
                        else
                        {
                            minNumber = minNumbersStack.Peek();
                        }

                    }

                    if (stack.Peek() == maxNumbersStack.Peek())
                    {
                        maxNumbersStack.Pop();

                        if(maxNumbersStack.Count == 0)
                        {
                            maxNumber = 1;
                        }
                        else
                        {
                            maxNumber = maxNumbersStack.Peek();
                        }
                    }

                    stack.Pop();
                        break;

                case 3:
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(maxNumber);
                    break;

                case 4:
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(minNumber);
                    break;
            }
        }

        if (stack.Count > 0)
        {
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());

                if (stack.Count > 0)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}