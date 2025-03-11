using _04.BorderControl.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; }
        public string Id { get; }
    }
}
