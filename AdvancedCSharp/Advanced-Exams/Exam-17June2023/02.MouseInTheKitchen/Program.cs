namespace _02.MouseInTheKitchen
{
    internal class Program
    {

        class Mouse
        {
            public int MouseRow { get; set; }
            public int MouseColumn { get; set; }
        }
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[numbers[0], numbers[1]];

            Mouse mouse = new Mouse();
            int countCheese = 0;

            for (int i = 0; i < numbers[0]; i++)
            {
                string input = Console.ReadLine()!;

                for (int j = 0; j < numbers[1]; j++)
                {
                    field[i, j] = input[j];

                    if (field[i, j] == 'M')
                    {
                        mouse.MouseRow = i;
                        mouse.MouseColumn = j;

                        field[i, j] = '*';
                    }
                    if (field[i, j] == 'C')
                    {
                        countCheese++;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()!) != "danger")
            {
                Mouse oldPosition = new();
                oldPosition = Position(mouse);

                mouse = Movement(mouse, command);

                if (mouse.MouseRow < 0 || mouse.MouseRow > field.GetLength(0) - 1 ||
                    mouse.MouseColumn < 0 || mouse.MouseColumn > field.GetLength(1) - 1)
                {
                    mouse = Position(oldPosition);

                    Console.WriteLine("No more cheese for tonight!");
                    PrintField(field, mouse);
                    return;
                }

                if (field[mouse.MouseRow, mouse.MouseColumn] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    PrintField(field, mouse);
                    return;
                }

                if (field[mouse.MouseRow, mouse.MouseColumn] == 'C')
                {
                    field[mouse.MouseRow, mouse.MouseColumn] = '*';
                    countCheese--;

                    if (countCheese == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        PrintField(field, mouse);
                        return;
                    }
                }

                if (field[mouse.MouseRow, mouse.MouseColumn] == '@')
                {
                    mouse = Position(oldPosition);
                    continue;
                }
            }

            Console.WriteLine("Mouse will come back later!");
            PrintField(field, mouse);
        }
        static Mouse Movement(Mouse mouse, string command)
        {
            if (command == "up")
            {
                mouse.MouseRow -= 1;
            }
            else if (command == "down")
            {
                mouse.MouseRow += 1;
            }
            else if (command == "left")
            {
                mouse.MouseColumn -= 1;
            }
            else //if(command == "right")
            {
                mouse.MouseColumn += 1;
            }

            return mouse;
        }

        static void PrintField(char[,] field, Mouse mouse)
        {
            field[mouse.MouseRow, mouse.MouseColumn] = 'M';

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        static Mouse Position(Mouse mouse)
        {
            Mouse newPosition = new();
            newPosition.MouseRow = mouse.MouseRow;
            newPosition.MouseColumn = mouse.MouseColumn;
            return newPosition;
        }
    }
}
