using System.ComponentModel;

namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string criteria = commands[1];
                string sample = commands[2];
                names = RemoveOrDouble(names, action, ActionChecker, criteria, sample, CriteriaChecker);
            }

            if (names.Length > 0)
            {
                Console.Write(string.Join(", ", names));
                Console.Write(" are going to the party!");
            }
            else 
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
        static string[] RemoveOrDouble
            (string[] names, string action, Func<string, bool> checker,
            string criteria, string sample, Func<string, string, string, bool> criteriaChecker)
        {
            List<string> list = new();
            foreach (string name in names)
            {
                list.Add(name);

                if (checker(action))
                {
                    list.Add(CriteriaChecker(name, criteria, sample, criteriaChecker));
                }
                else
                {
                    list.Remove(CriteriaChecker(name, criteria, sample, criteriaChecker));
                }

            }
            return list.Where(x => x != null).ToArray();
        }
        static bool ActionChecker(string action)
        {
            if (action == "Double")
            {
                return true;
            }
            return false;
        }

        static string CriteriaChecker
            (string name, string criteria, string sample, Func<string, string, string, bool> criteriaChecker)
        {
            if (criteriaChecker(criteria, sample, name))
            {
                return name;
            }

            return null;

        }

        static bool CriteriaChecker(string criteria, string sample, string name)
        {
            if (criteria == "StartsWith")
            {
                return name.StartsWith(sample);
            }
            else if (criteria == "EndsWith")
            {
                return name.EndsWith(sample);
            }
            else
            {
                return name.Length == int.Parse(sample);
            }
        }
    }
}