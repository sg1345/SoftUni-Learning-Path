internal class Program
{
    static void Main()
    {

        var text = "";
        
        for (int i = 3; i >= 1; i--)
        {
            var character = char.Parse(Console.ReadLine());
            
            text += character;

        }  



        Console.WriteLine(text);
    }
}
