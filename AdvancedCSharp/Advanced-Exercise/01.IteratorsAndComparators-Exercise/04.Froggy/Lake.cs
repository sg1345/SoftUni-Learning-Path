using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Froggy
{
    internal class Lake : IEnumerable<int>
    {
        public Lake(params int[] list)
        {
            List = new(list);
        }

        List<int> List { get; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.List.Count; i += 2)
            {
                yield return this.List[i];
            }
            int removal = this.List.Count % 2;

            for (int i = this.List.Count - 1 - removal; i >= 0; i -= 2)
            {
                yield return this.List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
