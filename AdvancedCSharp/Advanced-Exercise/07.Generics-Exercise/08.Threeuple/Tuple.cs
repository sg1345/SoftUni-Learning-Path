using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Threeuple
{
    public class Threeuple<T, T2, T3>
    {
        private T first;
        private T2 second;
        private T3 third;

        public Threeuple(T first, T2 second, T3 third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public T First { get => first; set => first = value; }
        public T2 Second { get => second; set => second = value; }
        public T3 Third { get => third; set => third = value; }

        public override string ToString()
        {
            return $"{this.First} -> {this.Second} -> {this.Third}";
        }
    }
}
