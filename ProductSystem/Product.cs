namespace ProductSystem;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, decimal price, string category)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), "El identificador debe ser mayor que cero.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(name));

        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "El precio base no puede ser negativo.");

        if (!IsValidCategory(category))
            throw new ArgumentException("La categoría no es válida. Solo se permiten 'Electrónica' y 'Alimentos'.", nameof(category));

        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public static bool IsValidCategory(string category)
    {
        return category == "Electrónica" || category == "Alimentos";
    }
}
