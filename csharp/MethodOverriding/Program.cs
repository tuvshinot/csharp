using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverridingPolymorphism
{
    public class Circle:Shape
    {
        public int Radius { get; set; }

        public override void Draw()
        {
            Console.WriteLine("Drawing cicle!");
        }
    }

    public class Retancle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Retangle!");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Retancle());

            var canvas = new Canvas();
            canvas.DrawShapes(shapes); 

            var shape = new Shape();
            
            Circle circle = (Circle)shape; // parent to child

        }
    }
}
