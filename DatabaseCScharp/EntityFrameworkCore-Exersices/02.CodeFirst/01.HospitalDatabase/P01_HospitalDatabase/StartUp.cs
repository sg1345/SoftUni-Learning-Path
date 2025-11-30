using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                using HospitalContext context = new HospitalContext();

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
