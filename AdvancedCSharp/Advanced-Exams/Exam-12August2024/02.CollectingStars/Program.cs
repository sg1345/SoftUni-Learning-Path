using System.Data;

namespace _02.CollectingStars
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
            int number = int.Parse(Console.ReadLine()!);

            char[,] field = new char[number, number];

            Coordinates player = new Coordinates();

            for (int i = 0; i < number; i++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < number; j++)
                {
                    field[i, j] = line[j];

                    if (field[i, j] == 'P')
                    {
                        player.Row = i;
                        player.Column = j;

                        field[i, j] = '.';
                    }
                }
            }

            int StarsCollected = 2;

            while (StarsCollected > 0 && StarsCollected < 10)
            {
                string command = Console.ReadLine()!;

                Coordinates OldPosition = new Coordinates();
                OldPosition.Row = player.Row;
                OldPosition.Column = player.Column;

                player = MovementWithinTheField(command, player, field);



                if (field[player.Row, player.Column] == '#')
                {
                    StarsCollected--;
                    player.Row = OldPosition.Row;
                    player.Column = OldPosition.Column;
                }

                if (field[player.Row, player.Column] == '*')
                {
                    field[player.Row, player.Column] = '.';
                    StarsCollected++;
                }
            }

            field[player.Row, player.Column] = 'P';

            if(StarsCollected == 10)
            {
                Console.WriteLine("You won! You have collected 10 stars.");
            }
            else //if(StarsCollected == 0)
            {
                Console.WriteLine("Game over! You are out of any stars.");
            }

            Console.WriteLine($"Your final position is [{player.Row}, {player.Column}]");

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write($"{field[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static Coordinates MovementWithinTheField(string command, Coordinates player, char[,] field)
        {
            if (command == "up")
            {
                if ((player.Row - 1) < 0)
                {
                    
                    return DefaultPosition();
                }

                player.Row -= 1;
                return player;
            }
            else if (command == "down")
            {
                if ((player.Row + 1) > field.GetLength(0) - 1)
                {
                    return DefaultPosition();
                }

                player.Row += 1;
                return player;
            }
            else if (command == "left")
            {
                if ((player.Column - 1) < 0)
                {
                    return DefaultPosition();
                }

                player.Column -= 1;
                return player;
            }
            else //if (command == "right")
            {
                if ((player.Column + 1) > field.GetLength(1) - 1)
                {
                    return DefaultPosition();
                }

                player.Column += 1;
                return player;
            }
        }

        private static Coordinates DefaultPosition()
        {
            Coordinates defaultPosition = new Coordinates();
            defaultPosition.Row = 0;
            defaultPosition.Column = 0;
            return defaultPosition;
        }
    }
}
