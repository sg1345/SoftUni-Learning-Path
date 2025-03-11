using _03.Telephony.Abstraction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class Smartphone : ICall, IBrowse
    {

        public string? PhoneNumber { get; private set; }

        public string? WebSite { get; private set; }

        public void AddNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public void AddWebsite(string webSite)
        {
            this.WebSite = webSite;
        }
        public void Browse()
        {
            if(WebSite!.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }

            Console.WriteLine($"Browsing: {WebSite}!");
        }

        public void Call()
        {
            if(PhoneNumber!.Any(char.IsLetter))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

                Console.WriteLine($"Calling... {this.PhoneNumber}");
        }
    }
}
