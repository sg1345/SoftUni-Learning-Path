using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public Stack<T>? stack { get; set; } = new Stack<T>();

        public void Push(params T[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                this.stack!.Push(values[i]);
            }
        }

        public void Pop()
        {
            if (this.stack!.Count != 0)
            {
                this.stack!.Pop();
                return;
            }

            Console.WriteLine("No elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] values = new T[this.stack!.Count];

            this.stack.CopyTo(values, 0);

            for (int i = 0; i < values.Length; i++)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

    }
}
