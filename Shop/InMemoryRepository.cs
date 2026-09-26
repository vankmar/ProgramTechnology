namespace Shop;

/// <summary>
/// класс для работы с информацией в памяти (тест)
/// </summary>
internal class InMemoryRepository : IRepository
{
    private readonly List<Supplier> _suppliers = new List<Supplier>();
    private readonly List<Category> _categories = new List<Category>();
    private readonly List<Product> _products = new List<Product>();

    /// <summary>
    /// конструктор заполнения хранилища информацией из кода
    /// </summary>
    public InMemoryRepository()
    {
        _suppliers = new List<Supplier>
        {
            new Supplier(1, "Samsung", "Южная Корея"),
            new Supplier(2, "Apple", "США"),
            new Supplier(3, "Яндекс", "Россия"),
            new Supplier(4, "Xiaomi", "Китай"),
            new Supplier(5, "DNS", "Россия")
        };

        _categories = new List<Category>
        {
            new Category(10, "Электроника", "бытовая техника"),
            new Category(20, "Смартфоны", "гаджеты и аксессуары"),
            new Category(30, "Умный дом", "устройства автоматизации"),
            new Category(40, "Ноутбуки", "портативные компьютеры"),
            new Category(50, "Аудио", "наушники и колонки")
        };

        _products = new List<Product>
        {
            new Product(101, "Ноутбук", 75000, 1, 40, 10),
            new Product(102, "iPhone 15", 95000, 2, 20, 5),
            new Product(103, "Умная колонка", 7000, 3, 30, 15),
            new Product(104, "Телевизор", 45000, 1, 10, 3),
            new Product(105, "Наушники Buds", 12000, 4, 50, 20)
        };
    }
    /// <summary>
    /// метод поиска поставщиков
    /// </summary>
    /// <returns> возвращает объект класса поставщиков </returns>
    public List<Supplier> GetSuppliers()
    { return _suppliers; }

    /// <summary>
    /// метод поиска категорий
    /// </summary>
    /// <returns> возвращает объект класса категорий </returns>
    public List<Category> GetCategories()
    { return _categories; }

    /// <summary>
    /// метод поиска товаров
    /// </summary>
    /// <returns> возвращает объект класса товаров </returns>
    public List<Product> GetProducts()
    { return _products; }
}
