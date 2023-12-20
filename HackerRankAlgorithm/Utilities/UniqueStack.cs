using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Utilities
{
    public class UniqueStack<T> : IEnumerable<T>
    {
        private Stack<T> stack = new Stack<T>();
        private HashSet<T> hashSet = new HashSet<T>();

        public bool Push(T item)
        {
            if (hashSet.Add(item))
            {
                stack.Push(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Pop()
        {
            var item =  stack.Pop();
            hashSet.Remove(item);
            return item;
        }

        public T Peek()
        {
            return stack.Peek(); 
        }

        public int Count => hashSet.Count;

        public IEnumerator<T> GetEnumerator() => stack.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
