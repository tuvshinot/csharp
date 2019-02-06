using System.Collections.Generic;

namespace MethodOverridingPolymorphism
{
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(); // different in every shape, This is what we call Polymorphism
            }
        }
    }
}