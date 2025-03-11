using _03.Telephony.Abstraction;

namespace _03.Telephony
{
    public class Program
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine()!
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            List<ICall> calls = new List<ICall>();
            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                    calls.Add(new StationaryPhone(phoneNumber));
                else if (phoneNumber.Length == 10)
                {
                    Smartphone smartPhone = new();
                    smartPhone.AddNumber(phoneNumber);
                    calls.Add(smartPhone);
                }
            }

            foreach (var call in calls)
            {
                call.Call();
            }

            string[] websites = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<IBrowse> browses = new List<IBrowse>();

            foreach (string website in websites)
            {
                Smartphone smartphone = new();
                smartphone.AddWebsite(website);
                browses.Add(smartphone);
            }

            foreach(var browse in browses)
            {
                browse.Browse();
            }

        }
    }
}
