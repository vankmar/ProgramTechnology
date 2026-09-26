namespace Shop;

/// <summary>
/// интерфейс. 
/// позволяет проще выбирать между несколькими репозиториями. 
/// определяет, какие методы обязаны быть в них.
/// </summary>
internal interface IRepository
{
    List<Supplier> GetSuppliers();
    List<Category> GetCategories();
    List<Product> GetProducts();
}
