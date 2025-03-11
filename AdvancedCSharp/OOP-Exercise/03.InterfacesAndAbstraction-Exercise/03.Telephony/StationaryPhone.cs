using _03.Telephony.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class StationaryPhone : ICall
    {
        private readonly string? _phoneNumber;

        public StationaryPhone(string? phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public void Call()
        {
            if(_phoneNumber!.Any(char.IsLetter))
                Console.WriteLine("Invalid number!");

                Console.WriteLine($"Dialing... {this._phoneNumber}");
        }
    }
}
