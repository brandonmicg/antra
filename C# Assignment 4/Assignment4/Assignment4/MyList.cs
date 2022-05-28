using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class MyList<T>
    {
        private Node<T>? Root { get; set; }

        public void Add(T element)
        {
            if (Root == null) 
                Root = new Node<T>(element, null);
            else
            {
                Node<T> tmp = Root;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                tmp.Next = new Node<T>(element, null);
            }
        }

        public T? Find(int index)
        {
            if (Root == null) return default;

            int i = 0;
            Node<T> tmp = Root;

            while (i < index)
            {
                if (tmp.Next == null) return default;
                tmp = tmp.Next;
                i++;
            }

            return tmp.Item;
        }

        public T? Remove(int index)
        {
            if (Root == null) return default;

            int i = 0;
            Node<T> prev = Root;
            Node<T> tmp = Root;

            while (i < index)
            {
                if (tmp.Next == null) 
                    return default(T);

                if (i == index - 1)
                    prev = tmp;

                tmp = tmp.Next;
                i++;
            }

            prev.Next = tmp.Next;
            T item = tmp.Item;
            tmp.Next = null;

            return item;
        }

        public bool Contains(T element)
        {
            if (Root == null) return false;

            Node<T> tmp = Root;

            do
            {
                if (tmp == null) return false;

                if (tmp.Item.Equals(element)) return true;

                tmp = tmp.Next;
            }
            while (tmp != null);

            return false;
        }

        public void Clear()
        {
            Root = null;
        }

        public void InsertAt(T element, int index)
        {
            if (Root == null) return;

            int i = 0;
            Node<T> tmp = Root;

            while (i < index - 1)
            {
                if (tmp.Next == null) return;
                tmp = tmp.Next;
                i++;
            }

            tmp.Next = new Node<T>(element, tmp.Next);
        }

        public void DeleteAt(int index)
        {
            Remove(index);
        }


        private class Node<T>
        {
            public T Item { get; set; }
            public Node<T>? Next { get; set; }

            public Node(T item, Node<T> next)
            {
                Item = item;
                Next = next;
            }
        }
    }
}
