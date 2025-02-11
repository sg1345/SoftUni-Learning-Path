
using GenericArrayCreator;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main()
        {
            string[] arr = ArrayCreator.Create(999,"aaaiaiai");

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
