using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDesign
{
    public class Stack
    {
        private ArrayList stack = new ArrayList();

        public void Push(object obj)
        {
            if (obj is object)
            {
                stack.Add(obj);
            }
            throw new ArgumentNullException("can not be null!");
        }

        public object Pop()
        {
            var index = stack.Count - 1;
            var toReturn = stack[index];
            stack.RemoveAt(index);

            return toReturn;
        }

        public void Clear()
        {
            stack = new ArrayList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

        }
    }
}
