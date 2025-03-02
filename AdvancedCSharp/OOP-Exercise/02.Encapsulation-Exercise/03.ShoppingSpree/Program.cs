namespace _03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, Person> people = ReadPeople();
                Dictionary<string, Product> catalogueOfProducts = ReadCatalogue();

                ProcessPurchasing(people, catalogueOfProducts);

                Console.WriteLine(string.Join('\n', people.Values));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ProcessPurchasing(Dictionary<string, Person> people, Dictionary<string, Product> catalogueOfProducts)
        {
            string command;
            while ((command = Console.ReadLine()!) != "END")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (people[data[0]].Buy(catalogueOfProducts, data[1]))
                {
                    Console.WriteLine($"{people[data[0]].Name} bought {data[1]}");
                }
                else
                {
                    Console.WriteLine($"{people[data[0]].Name} can't afford {data[1]}");
                }
            }
        }

        private static Dictionary<string, Product> ReadCatalogue()
        {
            string[] dataForProducts = Console.ReadLine()!
                            .Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Product> catalogueOfProducts = new Dictionary<string, Product>();

            foreach (string line in dataForProducts)
            {
                string[] info = line.Split('=');
                Product product = new Product(info[0], decimal.Parse(info[1]));
                catalogueOfProducts[product.Name] = product;
            }

            return catalogueOfProducts;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            string[] dataForPeople = Console.ReadLine()!
                            .Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> people = new Dictionary<string, Person>();

            foreach (string line in dataForPeople)
            {
                string[] info = line.Split('=');
                Person person = new Person(info[0], decimal.Parse(info[1]));
                people[person.Name] = person;
            }

            return people;
        }
    }
}
