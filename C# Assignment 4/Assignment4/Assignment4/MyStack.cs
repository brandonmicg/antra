using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class MyStack<T>
    {
        private int index = 0;
        private List<T> stack = new List<T>();

        public int Count()
        {
            return index;
        }

        public T Pop()
        {
            if (index == 0) return default(T);

            index--;
            T tmp = stack[index];
            stack.RemoveAt(index);
            return tmp;
        }

        public void Push(T item)
        {
            if (item == null) return;

            stack.Add(item);
            index++;
        }
    }
}
