namespace Shop;

/// <summary>
/// класс для методов    
/// </summary>
internal class Analytics
{
    /// <summary>
    /// метод поиска категории
    /// </summary>
    /// <param name="productName"> название товара, категорию которого ищем </param>
    /// <param name="products"> список товаров </param>
    /// <param name="categories"> список категорий </param>
    /// <returns> возвращает категорию данного товара или null </returns>
    public static Category FindCategory(string productName, List<Product> products, List<Category> categories)
    {
        if (productName == null || products == null || categories == null) 
        { throw new ArgumentOutOfRangeException("Данные некорректны"); }

        Product foundProduct = null;
        foreach (Product prod in products)
        {
            if (prod.Name == productName)
            {
                foundProduct = prod;
                break;
            }
        }
        if (foundProduct == null) return null;

        foreach (Category cat in categories)
            if (cat.Id == foundProduct.CategoryId) return cat;
        return null;
    }

    /// <summary>
    /// метод поиска поставщика товара
    /// </summary>
    /// <param name="productName"> название товара, поставщика которого ищем </param>
    /// <param name="products"> список товаров </param>
    /// <param name="suppliers"> список категорий </param>
    /// <returns> возвращает поставщика данного товара или null </returns>
    public static Supplier FindSupplier(string productName, List<Product> products, List<Supplier> suppliers)
    {
        if (productName == null || products == null || suppliers == null)
        { throw new ArgumentOutOfRangeException("Данные некорректны"); }

        Product foundProduct = null;
        foreach (Product prod in products)
        {
            if (prod.Name == productName)
            {
                foundProduct = prod;
                break;
            }
        }
        if (foundProduct == null) return null;

        foreach (Supplier sup in suppliers)
            if (sup.Id == foundProduct.SupplierId) return sup;
        return null;
    }

    /// <summary>
    /// метод нахождения общей стоимости товаров на складе
    /// </summary>
    /// <param name="products"> список товаров </param>
    /// <returns> общая стоимость или 0 </returns>
    public static double GetTotalPrice(List<Product> products)
    {
        if (products == null)
        { throw new ArgumentOutOfRangeException("Данные некорректны"); }

        double total = 0;
        foreach (Product prod in products)
            total = total + prod.TotalPrice;
        return total;
    }

    /// <summary>
    /// метод поиска самого дорогого товара для каждой категории
    /// </summary>
    /// <param name="products"> список товаров </param>
    /// <param name="categories"> список категорий </param>
    /// <returns> словарь с парами категория - товар </returns>
    public static Dictionary<string, Product> GetMostExpensiveProductPerCategory(List<Product> products, List<Category> categories)
    {
        if (products == null || categories == null)
        { throw new ArgumentOutOfRangeException("Данные некорректны"); }

        Dictionary<string, Product> result = new Dictionary<string, Product>();

        foreach (Product prod in products)
        {
            string categoryName = null;
            foreach (Category cat in categories)
            {
                if (cat.Id == prod.CategoryId)
                {
                    categoryName = cat.Name;
                    break;
                }
            }
            if (categoryName == null) continue;
            if (result.ContainsKey(categoryName) == false)
                result[categoryName] = prod;
            else { if (prod.Price > result[categoryName].Price) result[categoryName] = prod; }
        }
        return result;
    }

    /// <summary>
    /// вывод всех товаров
    /// </summary>
    /// <param name="products"> список товаров </param>
    /// <param name="categories"> список категорий </param>
    /// <param name="suppliers"> список поставщиков </param>
    public static void PrintAllProducts(List<Product> products, List<Category> categories, List<Supplier> suppliers)
    {
        if (products == null || categories == null || suppliers == null)
        { throw new ArgumentNullException("Данные некорректны"); }

        foreach (Product prod in products)
        {
            string catName = "—";
            foreach (Category cat in categories)
            {
                if (cat.Id == prod.CategoryId)
                {
                    catName = cat.Name;
                    break;
                }
            }

            string supName = "—";
            foreach (Supplier sup in suppliers)
            {
                if (sup.Id == prod.SupplierId)
                {
                    supName = sup.Name;
                    break;
                }
            }
            Console.WriteLine($"\"{prod.GetInfo()}\" — категория \"{catName}\", поставщик \"{supName}\"");
        }
    }
}
