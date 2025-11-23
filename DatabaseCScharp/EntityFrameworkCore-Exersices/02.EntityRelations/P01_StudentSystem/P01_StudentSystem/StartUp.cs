using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try 
            {
                using StudentSystemContext context = new StudentSystemContext();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("First Database Created!");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
