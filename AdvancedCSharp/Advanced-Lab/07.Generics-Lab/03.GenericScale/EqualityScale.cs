using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public T Left { get { return left; } set { left = value; } }
        public T Right { get { return right; } set { right = value; } }

        public bool AreEqual()
        {
            bool isTrue = this.Right.Equals(this.Left);
            return isTrue;
        }
    }
}
