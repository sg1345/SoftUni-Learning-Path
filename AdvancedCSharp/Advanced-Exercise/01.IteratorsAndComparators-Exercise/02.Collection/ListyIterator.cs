using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int _index;

        public ListyIterator()
        {
        }

        public ListyIterator(params T[] list)
        {
            List = new(list);
        }

        public List<T> List { get; }

        public bool Move()
        {
            if (_index >= List.Count) return false;

            if (_index < List.Count - 1)
            {
                _index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            int nextIndex = _index + 1;

            if (nextIndex >= List.Count)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (List != null && _index < List.Count)
            {
                Console.WriteLine($"{List[_index]}");
                return;
            }

            Console.WriteLine("Invalid Operation!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i< this.List.Count; i++)
            {
                yield return this.List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            =>GetEnumerator();
    }
}