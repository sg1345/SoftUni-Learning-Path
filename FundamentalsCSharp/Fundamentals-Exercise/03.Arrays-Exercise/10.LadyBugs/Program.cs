/*
5
0 1 2 3
3 left 1
1 left -4
end

 
 
 */


internal class Program
{
    static void Main()
    {
        var fieldSize = int.Parse(Console.ReadLine());
        var initialLocations = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var field = new int[fieldSize];

        for (int i = 0; i < initialLocations.Length; i++)
        {
            var currentIndex = initialLocations[i];

            if (currentIndex >= 0 && currentIndex < fieldSize)
            {
                field[currentIndex] = 1;
            }
        }



        while (true)
        {
            var input = Console.ReadLine();

            if (input == "end")
            {
                Console.WriteLine(string.Join(" ", field));
                break;
            }

            var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var ladybugIndex = int.Parse(command[0]);
            var direction = command[1];
            var flyLength = int.Parse(command[2]);

            if (ladybugIndex > field.Length - 1 || ladybugIndex < 0 || field[ladybugIndex] == 0)
            {
                continue;
            }

            if (direction == "right")
            {
                field[ladybugIndex] = 0;

                var firstLocation = ladybugIndex + flyLength;

                for (int i = firstLocation; i < field.Length; i += flyLength)
                {
                    if (i < 0)
                    {
                        break;
                    }

                    if (1 == field[i])
                    {
                        continue;
                    }

                    field[i] = 1;
                    break;

                }
            }
            else if (direction == "left")
            {
                field[ladybugIndex] = 0;

                var firstLocation = ladybugIndex - flyLength;

                for (int i = firstLocation; i >= 0; i -= flyLength)
                {
                    if (i >= field.Length)
                    {
                        break;
                    }

                    if (1 == field[i])
                    {
                        continue;
                    }

                    field[i] = 1;
                    break;
                }
            }
        }
    }
}