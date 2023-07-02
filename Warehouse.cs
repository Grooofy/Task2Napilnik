using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Napilnik
{
    public class Warehouse : IStoreProduct
    {
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();

        public void Deliver(Product product, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException();

            if (_products.ContainsKey(product))
                _products[product] += count;

            else
                _products.Add(product, count);
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("Товары:        Количество:");
            foreach (var product in _products)
                Console.Write(product.Key.Name + "          " + product.Value + "\n");
        }

        public int GetProductCount(Product product)
        {
            return _products[product];
        }

        public void SetNewProductCount(Product product, int newCount)
        {
            if (_products.ContainsKey(product))
            {
                if (_products[product] >= newCount)
                    _products[product] -= newCount;
                
                if (_products[product] == 0)
                    _products.Remove(product);
            }
        }
    }
}
