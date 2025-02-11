using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Tuple
{
    public class Tuple<T,T2>
    {
        private T first;
        private T2 second;

        public Tuple(T first, T2 second)
        {
            First = first;
            Second = second;
        }

        public T First { get => first; set => first = value; }
        public T2 Second { get => second; set => second = value; }


        public override string ToString()
        {
            return $"{First} -> {Second}";
        }
    }
}
