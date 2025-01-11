internal class Program
{
    static void Main()
    {
        string[] explession = Console.ReadLine().Split();

        Stack<string> stack = new Stack<string>();

        for (int i = explession.Length - 1; i >= 0; i--)
        {
            stack.Push(explession[i]);
        }

        int sum = int.Parse(stack.Pop());


        while (stack.Count > 0)
        {
            string operant = stack.Pop();
            int number = int.Parse(stack.Pop());
            if (operant == "-")
            {
               
                sum -= number;
            }
            else if (operant == "+")
            {                
                sum += number;
            }            
        }

        Console.WriteLine(sum);
    }
}
