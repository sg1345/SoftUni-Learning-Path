using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private T _value;

        public T Value { get => _value; set => _value = value; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }

        public int CountLarger(List<T> array)
        {
            int count = 0;
            foreach (T element in array)
            {
                if (element.CompareTo(_value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

