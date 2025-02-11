using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericArrayCreator;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] Array = new T[length];
            for (int i = 0; i <Array.Length; i++)
            {
                Array[i] = item;
            }

            return Array;
        }
    }
}
