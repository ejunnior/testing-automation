namespace Finance.Tests.StylesUnitTest
{
    using System.Collections.Generic;
    using System.Linq;

    public class Order
    {
        private readonly IList<Product> _products;

        public Order()
        {
            _products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products =>
            _products.ToList();

        public void AddProduct(Product product)
        {
            _products
                .Add(product);
        }
    }
}