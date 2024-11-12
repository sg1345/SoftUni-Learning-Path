internal class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> companyNameAndEmployeesID = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split("->")
                .Select(text => text.Trim())
                .ToArray();

            if(!companyNameAndEmployeesID.ContainsKey(info[0]))
            {
                companyNameAndEmployeesID[info[0]] = new();
            }

            if (companyNameAndEmployeesID[info[0]].Contains(info[1]))
            {
                continue;
            }

            companyNameAndEmployeesID[info[0]].Add(info[1]);
        }

        foreach (KeyValuePair<string,List<string>> companyEmplyees in companyNameAndEmployeesID)
        {
            Console.WriteLine(companyEmplyees.Key);

            Console.WriteLine("-- " + string.Join("\n-- ",companyEmplyees.Value));
        }
    }
}