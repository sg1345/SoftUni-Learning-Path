using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private int _index;

        public ListyIterator()
        {
        }

        public ListyIterator(params T[] list)
        {
            this.List = new(list);
        }

        public List<T> List { get; }

        public bool Move()
        {
            if (this._index >= this.List.Count) return false;

            if (this._index < this.List.Count - 1)
            {
                this._index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            int nextIndex = _index + 1;

            if (nextIndex >= this.List.Count)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (this.List != null && this._index < this.List.Count)
            {
                Console.WriteLine($"{this.List[this._index]}");
                return;
            }

            Console.WriteLine("Invalid Operation!");
        }
    }
}