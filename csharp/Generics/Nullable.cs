namespace GenericsDemo
{
    public class Nullable<T> where T : struct // value type can be nullable
    {
        private readonly object _value; // boxed it with object

        public Nullable()
        {
            
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            // value type can be nullable
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T) _value; // unboxing from object
            return default(T);
        }
    }
}