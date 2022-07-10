using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
    public class ListStack<T> : List<T>
    {
        public T Peek() => this[this.Count - 1];
        public T Push(T t) {
            this.Add(t);
            return t;
        }
        public T Pop()
        {
            var t = this.Peek();
            this.RemoveAt(this.Count - 1);
            return t;

        }
    }
}
