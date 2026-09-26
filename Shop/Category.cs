namespace Shop;

/// <summary>
/// класс категорий
/// </summary>
internal class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// свойство для получения информации о категории в одной строке
    /// </summary>
    public string Info
    {
        get { return $"{Name} — {Description}"; }
    }

    /// <summary>
    /// конструктор категории
    /// </summary>
    /// <param name="id"> id категории </param>
    /// <param name="name"> название категории </param>
    /// <param name="description"> описание категории </param>
    public Category(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
