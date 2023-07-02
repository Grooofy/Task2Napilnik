namespace Task2Napilnik
{
    public interface IStoreProduct
    {
        int GetProductCount(Product product);
        void SetNewProductCount(Product product, int newCount);
    }
}