using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter )
        {
            this.commandInterpreter = commandInterpreter ?? throw new ArgumentNullException(nameof(commandInterpreter)); 
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string output = this.commandInterpreter.Read(input);

                Console.WriteLine(output);
            }
        }
    }
}
