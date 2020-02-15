using System;
using System.Collections.Generic;

namespace GenericsAndCollections
{
    public class Search
    {
        /// <summary>
        /// This method finds the value in the array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns> index searched element or -1 if not found </returns>
        public static int Binary <T>(T [] array, T value)
        {
            bool decrease = IsSorted<T>(ref array, (T first, T second) => Comparer<T>.Default.Compare(first, second) > 0);
            bool increase = IsSorted<T>(ref array, (T first, T second) => Comparer<T>.Default.Compare(first, second) < 0);

            if(increase == true && decrease == true)
            {
                throw new ArgumentException("This array is unsorted");
            }

            int left = array.GetLowerBound(0);
            int right = array.GetUpperBound(0);

            if(left == right)
            {
                return left;
            }

            while(true)
            {
                if(right - left == 1)
                {
                    if(Comparer<T>.Default.Compare(array[left], value) == 0)
                    {
                        return left;
                    }

                    if(Comparer<T>.Default.Compare(array[right], value) == 0)
                    {
                        return right;
                    }

                    return -1;
                }
                else
                {
                    int middle = left + (right - left) / 2;

                    int result = 0;
                    if (increase)
                    {
                        result = Comparer<T>.Default.Compare(value, array[middle]);
                    }
                    else if(decrease)
                    {
                        result = Comparer<T>.Default.Compare(array[middle], value);
                    }

                    if (result == 0)
                    {
                        return middle;
                    }
                    else if (result < 0)
                    {
                        right = middle - 1;
                    }
                    else if(result > 0)
                    {
                        left = middle + 1;
                    }
                }
            }
        }

        private static bool IsSorted<T>(ref T [] array, Func<T, T, bool> typeSort)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (typeSort(array[i], array[i+1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
