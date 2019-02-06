using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractWhyWeUse
{
    public abstract class Shape // class has to be abstract
    {
        public abstract void Draw();  // drawing a shape is abstract (this is for leave implementation to derived classes)
        public abstract void Erase(); // no implementation

        /// These two MUST Implemented in derived class!

        public void Copy()
        {
            Console.WriteLine("Shape Copied!");
        }

        public void Select()
        {
            Console.WriteLine("Shape selected!");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing cicle!"); // 
        }

        public override void Erase()
        {
            Console.WriteLine("Erase circle!");
        }
    }

    public class Retancle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Retangle!");
        }

        public override void Erase()
        {
            Console.WriteLine("erase retangle!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // We cannot use shape cuz this is abstract just, declaration, or base class that has common behavior for derived classes
            /// var shape = new Shape();

            Circle circle = new Circle();
            circle.Draw();

            Retancle retancle = new Retancle();
            retancle.Draw();

        }
    }
}
