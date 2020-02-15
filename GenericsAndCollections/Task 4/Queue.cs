using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_4
{
    public class Queue<T> :IEnumerable<T>
    {
        Node<T> head;
        Node<T> last;

        public Queue(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("item is null");
            }

            Enqueue(item);
        }

        public Queue(T firstItem, T secondItem)
        {
            if(firstItem == null)
            {
                throw new ArgumentException("firstItem is null");
            }

            if(secondItem == null)
            {
                throw new ArgumentException("secondItem is null");
            }

            Enqueue(firstItem);
            Enqueue(secondItem);
        }

        public Queue(params T [] array)
        {
            if (array == null)
            {
                throw new ArgumentException("Array is null");
            }

            foreach(T item in array)
            {
                Enqueue(item);
            }
        }

        public T[] GetArray()
        {
            if(Count == 0)
            {
                return null;
            }

            T[] array = new T[Count];

            Node<T> temp = head;
            array[0] = temp.Data;

            for(int i = 1; i < Count; i++)
            {
                array[i] = temp.Next.Data;
                temp = temp.Next;
            }

            return array;
        }
        /// <summary>
        /// Retrieves and return the first item in a queue
        /// </summary>
        public T Dequeue()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var obj = head.Data;
            head = head.Next;

            Count--;

            return obj;
        }

        /// <summary>
        /// Adds an item to the end of the queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if(item == null)
            {
                throw new ArgumentException("item is null");
            }

            Node<T> newNode = new Node<T>(item);
            Node<T> temp = last;

            last = newNode;

            if(Count == 0)
            {
                head = last;
            }
            else
            {
                temp.Next = last;
            }

            Count++;
        }

        /// <summary>
        /// Returns the first element from the front of the queue without deleting it
        /// </summary>
        public T Peek()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return head.Data;
        }

        /// <summary>
        /// Returns the number of items on the queue
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
