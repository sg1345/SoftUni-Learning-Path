namespace _02.DeliveryBoy
{
    internal class Program
    {
        class DeliveryBoy
        {
            private readonly int _defaultRow;
            private readonly int _defaultColumn;

            public DeliveryBoy()
            {

            }

            public DeliveryBoy(int row, int column)
            {
                this.Row = row;
                this.Column = column;
                this.PizzaIsTaken = false;

                this._defaultRow = row;
                this._defaultColumn = column;
            }

            public int Row { get; set; }
            public int Column { get; set; }
            public bool PizzaIsTaken { get; set; }

            public int GetDefaultRow() => _defaultRow;
            public int GetDefaultColumn() => _defaultColumn;
        }

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[numbers[0], numbers[1]];

            DeliveryBoy player = new();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string input = Console.ReadLine()!;

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = input[j];

                    if (field[i, j] == 'B')
                    {
                        player = new(i, j);
                        field[i, j] = ' ';
                    }
                }
            }

            while (true)
            {
                DeliveryBoy oldPosition = new DeliveryBoy();
                oldPosition.Row = player.Row;
                oldPosition.Column = player.Column;

                string command = Console.ReadLine()!;

                player = Movement(player, command);

                if (player.Row < 0 || player.Row > field.GetLength(0) - 1 ||
                   player.Column < 0 || player.Column > field.GetLength(1) - 1)
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }

                if (field[player.Row, player.Column] == 'P')
                {
                    player.PizzaIsTaken = true;
                    field[player.Row, player.Column] = 'R';

                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }

                if (field[player.Row, player.Column] == '-')
                {
                    field[player.Row, player.Column] = '.';
                }

                if (field[player.Row, player.Column] == '*')
                {
                    player.Row = oldPosition.Row;
                    player.Column = oldPosition.Column;
                }

                if (field[player.Row, player.Column] == 'A' && player.PizzaIsTaken)
                {
                    field[player.Row, player.Column] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    field[player.GetDefaultRow(), player.GetDefaultColumn()] = 'B';
                    break;
                }
            }

            PrintField(field, player);
        }

        private static void PrintField(char[,] field, DeliveryBoy player)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        static DeliveryBoy Movement(DeliveryBoy player, string command)
        {
            if (command == "up")
            {
                player.Row -= 1;
            }
            else if (command == "down")
            {
                player.Row += 1;
            }
            else if (command == "left")
            {
                player.Column -= 1;
            }
            else //if ((command == "right"))
            {
                player.Column += 1;
            }

            return player;
        }
    }
}

