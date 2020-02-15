using System;
using System.Collections;

namespace GenericsAndCollections.Task_3
{
    public class Fibonacci : IEnumerable
    {
        public int N { get; set; }
        private int [] cache;

        public Fibonacci(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("n must be positive number");
            }

            N = n;
            cache = new int[2] { 1, 1 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerator GetEnumerator()
        {
            for(int i = 0; i < N; i++)
            {
                yield return fibo(i);
            }

            cache[0] = 1;
            cache[1] = 1;
        }

        private int fibo(int n)
        {
            if(n != 0 && n != 1)
            {
                int temp = cache[0];
                cache[0] = cache[0] + cache[1];
                cache[1] = temp;
            }

            return cache[0]; 
        }
    }
}
