namespace ProductSystem;

public class Product
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string Category { get; }

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

public class ProductManager
{
    private readonly List<Product> _products = [];

    public void AddProduct(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (product.Price < 0)
            throw new ArgumentOutOfRangeException(nameof(product), "El precio base no puede ser negativo.");

        if (!Product.IsValidCategory(product.Category))
            throw new ArgumentException("La categoría no es válida. Solo se permiten 'Electrónica' y 'Alimentos'.", nameof(product));

        _products.Add(product);
    }

    public decimal CalculateTotalPrice(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (product.Price < 0)
            throw new ArgumentOutOfRangeException(nameof(product), "El precio base no puede ser negativo.");

        decimal taxRate = product.Category switch
        {
            "Electrónica" => 0.10m,
            "Alimentos" => 0.05m,
            _ => throw new ArgumentException("La categoría no es válida. Solo se permiten 'Electrónica' y 'Alimentos'.", nameof(product))
        };

        return product.Price + (product.Price * taxRate);
    }

    public Product? FindProductByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _products.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}

