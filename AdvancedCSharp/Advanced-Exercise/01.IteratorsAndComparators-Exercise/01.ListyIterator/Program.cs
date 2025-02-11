namespace _01.ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string  input = Console.ReadLine();
            
            ListyIterator<string> list = new();

            string[] command = input.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);

            if (command.Length > 1)
            {               
                list = new ListyIterator<string>(command[1..]);
            }

            while ((input = Console.ReadLine())!= "END")
            {                                              
                switch (input)
                {
                    case "Move":

                        Console.WriteLine(list.Move());
                        break;
                    case "Print":

                        list.Print();
                        break;
                    case "HasNext":

                        Console.WriteLine(list.HasNext());                       
                        break;
                }
            }
        }
    }
}