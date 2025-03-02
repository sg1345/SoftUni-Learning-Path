namespace _02.Solution
{
    internal class Program
    {
        class Coordinates
        {
            public int Row { get; set; }
            public int Column { get; set; }


        }

        static void Main(string[] args)
        {
            //int number = int.Parse(Console.ReadLine()!);
            //char[,] field = new char[number, number];

            int[] numbers = Console.ReadLine()!
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[numbers[0], numbers[1]];

            Coordinates courier = new Coordinates();
            Coordinates deliveryPoint = new Coordinates();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string input = Console.ReadLine()!;

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = input[j];

                    if (field[i, j] == 'V')
                    {
                        courier.Row = i;
                        courier.Column = j;
                        field[courier.Row, courier.Column] = '*';
                    }

                    if (field[i, j] == 'D')
                    {
                        deliveryPoint.Row = i;
                        deliveryPoint.Column = j;
                    }
                }
            }

            Coordinates defaultPosition = new Coordinates();
            defaultPosition.Row = courier.Row;
            defaultPosition.Column = courier.Column;

            bool isCompleted = false;
            int countTrafficJams = 0;
            while (countTrafficJams < 3)
            {
                Coordinates oldCoordinates = new();
                oldCoordinates.Row = courier.Row;
                oldCoordinates.Column = courier.Column;

                string command = Console.ReadLine()!;

                courier = MovementWithinTheField(command, courier, field);

                if (courier.Row < 0 || courier.Row > field.GetLength(0) - 1 ||
                    courier.Column < 0 || courier.Column > field.GetLength(1) - 1)
                {
                    courier.Row = oldCoordinates.Row;
                    courier.Column = oldCoordinates.Column;
                    continue;
                }
                else if (field[courier.Row, courier.Column] == 'X')
                {
                    countTrafficJams++;
                    field[courier.Row, courier.Column] = '*';

                    courier.Row = oldCoordinates.Row;
                    courier.Column = oldCoordinates.Column;
                    continue;
                }
                else if (field[courier.Row, courier.Column] == 'D')
                {
                    courier.Row = defaultPosition.Row;
                    courier.Column = defaultPosition.Column;
                    isCompleted = true;
                    break;
                }
            }

            if (isCompleted)
            {
                Console.WriteLine("Delivery completed!");
                field[courier.Row, courier.Column] = 'V';
                PrintField(field);
            }
            else if (!isCompleted)
            {
                Console.WriteLine("Delivery failed, too many traffic jams!");
                field[deliveryPoint.Row, deliveryPoint.Column] = '*';
                field[courier.Row, courier.Column] = 'V';
                PrintField(field);
            }
        }

        static Coordinates MovementWithinTheField(string command, Coordinates player, char[,] field)
        {
            if (command == "up")
            {
                player.Row -= 1;
                return player;
            }
            else if (command == "down")
            {
                player.Row += 1;
                return player;
            }
            else if (command == "left")
            {
                player.Column -= 1;
                return player;
            }
            else //if (command == "right")
            {
                player.Column += 1;
                return player;
            }
        }

        static void PrintField(char[,] field)
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
    }
}
