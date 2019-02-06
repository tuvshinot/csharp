using System;

namespace GenericsDemo
{
    public class Utulities<T> where T : IComparable, new()  // instantiate class itself
    {
        /// simple
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();
        }

        /// Generic version
        public T Max(T a, T b) 
        {
            return a.CompareTo(b) > 0 ? a : b; 
        }
    }
}


//  public T Max<T>(T a, T b) where T : IComparable
//    {
//      return a.CompareTo(b) > 0 ? a : b;
//    }