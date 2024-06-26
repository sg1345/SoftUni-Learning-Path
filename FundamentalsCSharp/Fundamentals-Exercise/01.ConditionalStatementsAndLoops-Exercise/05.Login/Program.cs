internal class Program
{
    static void Main()
    {
        var username = Console.ReadLine(); //dimitar

        var password = "";

        char[] characters = username.ToCharArray(); // d i m i t a r
        

        for (int i = username.Length-1; i >= 0; i--)  // 6
        {
            password += characters[i];
        }
        
        var count = 4;
        
        
        while (true)
            {
            var input = Console.ReadLine();
            count--;
            if (password == input)
            {
                Console.WriteLine($"User {username} logged in.");
                break;
            }
            else if (count == 0)
            {
                Console.WriteLine($"User {username} blocked!");
                break;
            }
            else
            {
                Console.WriteLine("Incorrect password. Try again.");
            }
        }

    }
}