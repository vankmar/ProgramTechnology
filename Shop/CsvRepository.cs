namespace Shop;

/// <summary>
/// класс для работы с .csv файлами
/// </summary>
internal class CsvRepository : IRepository
{
    /// <summary>
    /// полный адрес файла
    /// </summary>
    private string _basePath;

    /// <summary>
    /// конструктор заполнения хранилища информацией из файла
    /// </summary>
    /// <param name="basePath"> полный адрес файла </param>
    public CsvRepository(string basePath)
    { _basePath = basePath; }

    /// <summary>
    /// метод поиска поставщиков
    /// </summary>
    /// <returns> возвращает объект класса поставщиков </returns>
    public List<Supplier> GetSuppliers()
    {
        List<Supplier> result = new List<Supplier>();

        string filePath = Path.Combine(_basePath, "suppliers.csv");
        if (!File.Exists(filePath)) return result;
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length < 2) return result; // если только заголовок или еще меньше то выходим

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue; // проверка что строка полная

            int id = int.Parse(parts[0]);
            string name = parts[1];
            string country = parts[2];

            Supplier s = new Supplier(id, name, country);
            result.Add(s);
        }
        return result;
    }

    /// <summary>
    /// метод поиска категорий
    /// </summary>
    /// <returns> возвращает объект класса категорий </returns>
    public List<Category> GetCategories()
    {
        List<Category> result = new List<Category>();

        string filePath = Path.Combine(_basePath, "categories.csv");
        if (!File.Exists(filePath)) return result;
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 3) continue;

            int id = int.Parse(parts[0]);
            string name = parts[1];
            string description = parts[2];

            Category c = new Category(id, name, description);
            result.Add(c);
        }
        return result;
    }

    /// <summary>
    /// метод поиска товаров
    /// </summary>
    /// <returns> возвращает объект класса товаров </returns>
    public List<Product> GetProducts()
    {
        List<Product> result = new List<Product>();
        string filePath = Path.Combine(_basePath, "products.csv");

        if (!File.Exists(filePath)) return result;

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length < 2) return result;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts.Length < 6) continue;

            int id = int.Parse(parts[0]);
            string name = parts[1];
            double price = double.Parse(parts[2]);

            int supplierId = int.Parse(parts[3]);
            int categoryId = int.Parse(parts[4]);
            int quantity = int.Parse(parts[5]);

            Product p = new Product(id, name, price, supplierId, categoryId, quantity);
            result.Add(p);
        }
        return result;
    }
}
