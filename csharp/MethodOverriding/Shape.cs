namespace MethodOverridingPolymorphism
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void Draw()
        {
            // different in every shape
        }

    }
}