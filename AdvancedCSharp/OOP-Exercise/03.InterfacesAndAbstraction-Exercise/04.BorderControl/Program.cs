using _04.BorderControl.Abstraction;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main()
        {
            List<IIdentifiable> list = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()!) != "End")
            {
                string[] data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                if (data.Length == 3 )
                {
                    Citizen citizen = new(data[0], int.Parse(data[1]), data[2]);
                    list.Add(citizen);
                }
                else if (data.Length == 2 )
                {
                    Robot robot = new(data[0], data[1]);
                    list.Add(robot);
                }
            }

            string marker = Console.ReadLine();

            foreach (var id in list.Where(x=>x.Id.EndsWith(marker)))
            {
                Console.WriteLine(id.Id);
            }
        }
    }
}
