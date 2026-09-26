using System.Diagnostics.Metrics;

namespace Shop;

/// <summary>
/// класс товаров 
/// </summary>
internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public int Quantity { get; set; }

    /// <summary>
    /// свойство - общая стоимость товаров на складе
    /// </summary>
    public double TotalPrice
    {
        get { return Price * Quantity; }
    }

    /// <summary>
    /// свойство - дороже ли товар 10000 р.
    /// </summary>
    public bool IsExpensive
    {
        get { return Price > 10000; }
    }

    /// <summary>
    /// конструктор товаров
    /// </summary>
    /// <param name="id"> id товара </param>
    /// <param name="name"> название товара </param>
    /// <param name="price"> цена товара </param>
    /// <param name="supplierId"> id поставщика товара </param>
    /// <param name="categoryId"> id категории товара </param>
    /// <param name="quantity"> количество товара </param>
    public Product(int id, string name, double price, int supplierId, int categoryId, int quantity)
    {
        Id = id;
        Name = name;

        if (price < 0) { throw new ArgumentOutOfRangeException(nameof(price), "Цена товара не может быть отрицательным"); }
        Price = price;

        SupplierId = supplierId;
        CategoryId = categoryId;

        if (quantity < 0) { throw new ArgumentOutOfRangeException(nameof(quantity), "Количество товаров не может быть отрицательным"); }
        Quantity = quantity;
    }

    /// <summary>
    /// метод получения информации о товаре в одной строке
    /// </summary>
    /// <returns> возвращает строку </returns>
    public string GetInfo()
    {
        if (Name == null || Price == null || Quantity == null) return "Не вышло найти информацию о товаре";
        else return $"{Name} ({Price} руб., {Quantity} шт.)";
    }
}
