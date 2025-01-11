internal class Program
{
    static void Main()
    {
        string MathExpression = Console.ReadLine();

        Stack<int> stack = new();

        for (int i = 0; i < MathExpression.Length; i++)
        {
            if (MathExpression[i] == '(')
            {
                stack.Push(i);
            }

            if (MathExpression[i] == ')')
            {
                int leftBracket = stack.Pop();
                int rightBracket = i;

                string subExpression = string.Empty;

                for (int j = leftBracket; j <= rightBracket; j++)
                {
                    subExpression += MathExpression[j];
                }

                Console.WriteLine(subExpression);
            }
        }
    }
}