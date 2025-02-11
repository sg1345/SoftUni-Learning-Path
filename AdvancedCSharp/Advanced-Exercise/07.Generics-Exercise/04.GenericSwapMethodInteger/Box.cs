using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T> : Box
    {
        private T? _value;

        public T Value { get => _value!; set => _value = value; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}

