using System.Diagnostics;

namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];
                string criteria = command[1];
                string sample = command[2];

                Predicate<string> match = GetNames(criteria, sample);

                names = ListManipulator(names, match, action);
            }

            if (names.Count > 0)
            {
                Console.Write(string.Join(", ", names));
                Console.Write(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        static List<string> ListManipulator(List<string> names, Predicate<string> match, string action)
        {
            if (action == "Double")
            {
                return names.SelectMany(name => match(name) ? new[] { name, name } : new[] { name })
                    .ToList();
            }
            else if (action == "Remove")
            {
                return names.Where(name => !match(name)).ToList();
            }
            return names;

            //List<string> list = new List<string>();
            //foreach (string name in names)
            //{
            //    list.Add(name);
            //    if (action == "Double" && match(name))
            //    {
            //        list.Add(name);
            //    }
            //    else if (action =="Remove" && match(name))
            //    {
            //        list.Remove(name);
            //    }
            //}
            //return list;
        }

        static Predicate<string> GetNames(string criteria, string sample)
        {
            return criteria switch
            {
                "StartsWith" => name => name.StartsWith(sample),
                "EndsWith" => name => name.EndsWith(sample),
                "Length" => name => name.Length == int.Parse(sample),
                _ => _ => false
            };
        }
    }
}
