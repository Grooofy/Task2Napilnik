using System.Text;
using Task2Napilnik;

namespace Task2
{
    public class Cart
    {
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        private IStoreProduct _storeProduct;

        public Cart(IStoreProduct storeProduct)
        {
            _storeProduct = storeProduct;
        }

        public Order Order()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var product in _products)
                stringBuilder.Append($"{product.Key.Name}: {product.Value}.");

            return new Order(stringBuilder.ToString());
        }

        public void Add(Product product, int count)
        {
            if (_storeProduct.GetProductCount(product) < count)
            {
                Console.WriteLine("Нет на складе");
                return;
            }

            if (_products.ContainsKey(product))
            {
                _products[product] += count;
                _storeProduct.SetNewProductCount(product,count);
            }
            else
            {
                _products.Add(product, count);
                _storeProduct.SetNewProductCount(product, count);
            }
                
        }
    }
}