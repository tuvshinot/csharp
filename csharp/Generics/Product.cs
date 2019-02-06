namespace GenericsDemo
{

    // : Product !!!!!!!!!! TYPE
    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Book : Product
    {
        public string isbn { get; set; }
    }

    public class DisocuntCalc<TProduct> where TProduct : Product
    {
        public float CalcDis(TProduct product)
        {
            // access to properties
            return product.Price;
        }
    }
}