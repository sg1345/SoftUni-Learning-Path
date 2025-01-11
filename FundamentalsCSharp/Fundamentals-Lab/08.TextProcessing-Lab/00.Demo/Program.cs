namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //for (int i = 0; i < number; i++)
            //{
            //    //string line = new string('*',number);
            //    //string newLine = string.Join(' ', line.ToArray());

            //    string line = string.Join(' ', new string('*', number).ToArray());

            //    Console.WriteLine(line);
            //}

            //for (int i = 0; i < number; i++)
            //{
            //    string space = new string(' ', i);
            //    string line = string.Join(' ', new string('*', number).ToArray());

            //    string final = space + line;
            //    Console.WriteLine(final);
            //}

            //for (int i = 0; i < number; i++)
            //{
            //    string space = new string(' ', number - i);
            //    string line = string.Join(' ', new string('*', i).ToArray());
            //    Console.WriteLine(space + line);
            //}
            //for (int i = number - 2; i >= 0; i--)
            //{
            //    string space = new string(' ', number - i);
            //    string line = string.Join(' ', new string('*', i).ToArray());
            //    Console.WriteLine(space + line);               
            //}
            while (number > 0)
            {
                int playerNumber = 0;

                if (number >= 15)
                {
                    playerNumber = 15;
                    number -= 15;
                }
                else
                {
                    playerNumber = number;
                    number = 0;
                }

                for (int i = 0; i < playerNumber; i++)
                {
                    if (IsOneStar(i))
                    {
                        Console.WriteLine(new string(' ', 4) + "*");
                    }
                    else if (IsThreeStars(i))
                    {
                        Console.WriteLine(new string(' ', 3) + "***");
                    }
                    else if (IsFiveStars(i))
                    {
                        Console.WriteLine(new string(' ', 2) + "*****");
                    }
                    else
                    {
                        Console.WriteLine(new string(' ', 1) + "*******");
                    }
                }
            }


        }

        private static bool IsOneStar(int i)
        {
            return i == 0 || i == 3 || i == 14;
        }

        private static bool IsThreeStars(int i)
        {
            return i == 1 || i == 4 || i == 6 || i == 13;
        }

        private static bool IsFiveStars(int i)
        {
            return i == 2 || i == 5 || i == 7 || i == 8 || i == 11 || i == 12;
        }
    }
}
