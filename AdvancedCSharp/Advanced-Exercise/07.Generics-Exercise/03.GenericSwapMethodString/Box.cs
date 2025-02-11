using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
    {
        private T _value;

        public T Value { get => _value; set => _value = value; }

        public Box(T value)
        {
            Value = value;
        }

        public static void Swap<T>(T[] array, int index1, int index2)
        {
            (array[index1], array[index2]) = (array[index2], array[index1]);

            //return array;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Value}";
        }
    }
}

