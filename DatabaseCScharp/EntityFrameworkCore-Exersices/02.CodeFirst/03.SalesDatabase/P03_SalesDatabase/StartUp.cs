using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                using SalesContext context = new SalesContext();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

