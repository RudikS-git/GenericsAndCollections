using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_6
{
    public class Set<T> : IEnumerable<T>
    {
        private List<T> list = new List<T>();

        public Set(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("item is null");
            }

            Add(item);
        }

        public Set(T firstItem, T secondItem)
        {
            if (firstItem == null)
            {
                throw new ArgumentException("firstItem is null");
            }

            if (secondItem == null)
            {
                throw new ArgumentException("secondItem is null");
            }

            Add(firstItem);
            Add(secondItem);
        }

        public Set(params T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException("Array is null");
            }

            foreach (T item in array)
            {
                Add(item);
            }
        }

        public T[] GetArray()
        {
            if (list.Count == 0)
            {
                return null;
            }

            return list.ToArray();
        }

        public void Add(T item)
        {
            if(item == null)
            {
                throw new ArgumentException("item is null");
            }

            if(!list.Contains(item))
            {
                list.Add(item);
            }
        }

        public void Remove(T item)
        {
            if(item == null)
            {
                throw new ArgumentException("item is null");
            }

            if(list.Contains(item))
            {
                list.Remove(item);
            }
            else
            {
                throw new KeyNotFoundException("This key is not found");
            }
        }

        public static Set<T> Union(Set<T> firstSet, Set<T> secondSet)
        {
            Validation(ref firstSet, ref secondSet);

            List<T> temp = new List<T>();

            temp.AddRange(firstSet);
            temp.AddRange(secondSet);

            Set<T> resultSet = new Set<T>();

            foreach(var item in temp)
            {
                if(!resultSet.list.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            return resultSet;
        }

        public static Set<T> Difference(Set<T> firstSet, Set<T> secondSet)
        {
            Validation(ref firstSet, ref secondSet);

            Set<T> resultSet = new Set<T>();

            for (int i = 0; i < firstSet.list.Count; i++)
            {
                if(!secondSet.list.Contains(firstSet.list[i]))
                {
                    resultSet.list.Add(firstSet.list[i]);
                }
            }

            return resultSet;
        }

        public static Set<T> Intersection(Set<T> firstSet, Set<T> secondSet)
        {
            Validation(ref firstSet, ref secondSet);

            Set<T> resultSet = new Set<T>();

            if(firstSet.list.Count > secondSet.list.Count)
            {
                foreach (var item in secondSet)
                {
                    if (firstSet.list.Contains(item))
                    {
                        resultSet.list.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in firstSet)
                {
                    if (secondSet.list.Contains(item))
                    {
                        resultSet.list.Add(item);
                    }
                }
            }

            if(resultSet.list.Count == 0)
            {
                return null;
            }

            return resultSet;
        }

        private static void Validation(ref Set<T> firstSet, ref Set<T> secondSet)
        {
            if(firstSet == null)
            {
                throw new ArgumentException(nameof(firstSet));
            }
            else if(secondSet == null)
            {
                throw new ArgumentException(nameof(secondSet));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
