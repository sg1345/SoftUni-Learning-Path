using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    internal class Box<T>
    {
        private List<T> _value = new();
        //private int _count;
        public List<T> Value { get => _value; set => _value = value; }
        public int Count { get => this.Value.Count; }

        public void Add(T value)
        {
            this.Value.Add(value);           
        }

        public T Remove()
        {
            var data = this.Value.Last();
            this.Value.RemoveAt(this.Value.Count - 1);
            return data;
        }

        //public int Count => this.Value.Count; 
    }
}
