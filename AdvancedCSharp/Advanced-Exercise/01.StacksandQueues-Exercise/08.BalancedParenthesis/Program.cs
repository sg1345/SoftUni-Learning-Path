using System.ComponentModel.Design;

internal class Program
{
    static void Main()
    {
        Stack<char> stack = new();

        string parenthesis = Console.ReadLine();

        for (int i = 0; i < parenthesis.Length; i++)
        {
            if (parenthesis[i] == '(')
            {
                stack.Push(')');
                continue;
            }
            else if (parenthesis[i] == '[')
            {
                stack.Push(']');
                continue;
            }
            else if (parenthesis[i] == '{')
            {
                stack.Push('}');
                continue;
            }

            if(stack.Count == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            if (parenthesis[i] == stack.Peek())
            {
                stack.Pop();
            }
            else
            {
                Console.WriteLine("NO");
                return;
            }
        }

        Console.WriteLine("YES");
    }
}