namespace Shop;

/// <summary>
///  класс поставщика
/// </summary>
class Supplier
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    /// <summary>
    /// свойство проверки на зарубежность
    /// </summary>
    public bool IsForeign
    {
        get { return Country != "Россия"; }
    }

    /// <summary>
    /// конструктор поставщика
    /// </summary>
    /// <param name="id"> id поставщика </param>
    /// <param name="name"> название поставщика </param>
    /// <param name="country"> страна поставщика </param>
    public Supplier(int id, string name, string country)
    {
        Id = id;
        Name = name;
        Country = country;
    }

    /// <summary>
    /// метод получения информации о поставщике в одной строке
    /// </summary>
    /// <returns> возвращает строку </returns>
    public string GetInfo()
    {
        if (Name == null || Country == null) return "Не вышло найти информацию о поставщике";
        else return $"{Name} ({Country})";
    }
}
