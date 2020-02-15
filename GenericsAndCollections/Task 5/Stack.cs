using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_5
{
    public class Stack<T> : IEnumerable<T>
    {
        Node<T> head;

        public Stack(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("item is null");
            }

            Push(item);
        }

        public Stack(T firstItem, T secondItem)
        {
            if (firstItem == null)
            {
                throw new ArgumentException("firstItem is null");
            }

            if (secondItem == null)
            {
                throw new ArgumentException("secondItem is null");
            }

            Push(firstItem);
            Push(secondItem);
        }

        public Stack(params T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException("Array is null");
            }

            foreach (T item in array)
            {
                Push(item);
            }
        }

        public T[] GetArray()
        {
            if (Count == 0)
            {
                return null;
            }

            T[] array = new T[Count];

            Node<T> temp = head;
            array[0] = temp.Data;

            for (int i = 1; i < Count; i++)
            {
                array[i] = temp.Next.Data;
                temp = temp.Next;
            }

            return array;
        }

        /// <summary>
        /// Returns the first item on the stack
        /// </summary>
        /// <returns>Last item in queue</returns>
        public T Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            var data = head.Data;
            head = head.Next;

            Count--;

            return data;
        }

        /// <summary>
        /// Pushes an item in the stack in first place
        /// </summary>
        /// <param name="obj"></param>
        public void Push(T obj)
        {
            Node<T> node = new Node<T>(obj);
            node.Next = head;
            head = node;

            Count++;
        }

        /// <summary>
        /// Returns the first item on the stack without deleting
        /// </summary>
        /// <returns>Last item in queue</returns>
        public T Peek()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return head.Data;
        }

        /// <summary>
        /// Returns the number of items on the stack
        /// </summary>
        /// <returns>First item in queue</returns>
        public int Count { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}
