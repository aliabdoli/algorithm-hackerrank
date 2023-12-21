using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Utilities
{
    /// <summary>
    /// if in Stack use Collection.Stack instead of LinkedList,
    ///     - complexity of Push when beyond capacity, becomes O(n), which makes it time out
    /// either use recursion stack or implement stack with Linkedlist!!! 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueStack<T> : IEnumerable<T>
    {
        private LinkedList<T> stack = new LinkedList<T>();
        private HashSet<T> hashSet = new HashSet<T>();

        public bool Push(T item)
        {
            if (hashSet.Add(item))
            {
                stack.AddFirst(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Pop()
        {
            var item = stack.First();
            stack.RemoveFirst();
            hashSet.Remove(item);
            return item;
        }

        public T Peek()
        {
            return stack.First(); 
        }

        public int Count => hashSet.Count;

        public IEnumerator<T> GetEnumerator() => stack.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
