

namespace _02.Beesy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()!);

            char[,] field = new char[number, number];

            int beeRow = 0;
            int beeCol = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string row = Console.ReadLine()!;

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = row[j];

                    if (field[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;

                        field[i, j] = '-';
                    }
                }
            }

            int honeyCollected = 0;
            int energy = 15;
            bool isReachedHive = false; 
            bool usedSecondLive = false;

            while (true)
            {
                string command = Console.ReadLine()!;
                energy--;

                beeRow = UpAndDownMovement(beeRow, command);
                beeCol = LeftAndrightMovement(beeCol, command);

                beeRow = FieldRulesMovement(number, beeRow);
                beeCol = FieldRulesMovement(number, beeCol);

                if (int.TryParse(field[beeRow, beeCol].ToString(), out int temp))
                {
                    honeyCollected += temp;
                    field[beeRow, beeCol] = '-';
                }

                if (field[beeRow, beeCol] == 'H')
                {
                    isReachedHive = true;
                    field[beeRow, beeCol] = 'B';
                    break;
                }

                if (energy == 0)
                {
                    if (honeyCollected > 30 && !usedSecondLive)
                    {
                        energy = honeyCollected - 30;
                        usedSecondLive = true;
                        continue;
                    }

                    field[beeRow, beeCol] = 'B';
                    break;
                }
            }

            PrintMessage(isReachedHive, honeyCollected, energy);
            PrintField(field);
        }

        private static void PrintMessage(bool isReachedHive, int honeyCollected, int energy)
        {
            if (isReachedHive && honeyCollected >= 30)
            {
                Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
            }
            else if (isReachedHive && energy < 30)
            {
                Console.WriteLine("Beesy did not manage to collect enough nectar.");
            }
            else if(!isReachedHive)
            {
                Console.WriteLine("This is the end! Beesy ran out of energy.");
            }
        }

        private static void PrintField(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static int LeftAndrightMovement(int beeCol, string command)
        {
            if (command == "left")
            {
                beeCol--;
            }
            else if (command == "right")
            {
                beeCol++;
            }

            return beeCol;
        }

        private static int UpAndDownMovement(int beeRow, string command)
        {
            if (command == "up")
            {
                beeRow--;
            }
            else if (command == "down")
            {
                beeRow++;
            }

            return beeRow;
        }

        private static int FieldRulesMovement(int bounds, int beePosition)
        {
            if (beePosition < 0)
            {
                beePosition = bounds - 1;
            }
            else if (beePosition > bounds - 1)
            {
                beePosition = 0;
            }

            return beePosition;
        }
    }
}
