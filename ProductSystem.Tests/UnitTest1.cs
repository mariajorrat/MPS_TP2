namespace ProductSystem.Tests;

public class ProductTests
{
    [Test]
    public void Product_CreatesWithValidData()
    {
        var product = new Product(1, "Mouse", 500m, "Electrónica");

        Assert.That(product.Id, Is.EqualTo(1));
        Assert.That(product.Name, Is.EqualTo("Mouse"));
        Assert.That(product.Price, Is.EqualTo(500m));
        Assert.That(product.Category, Is.EqualTo("Electrónica"));
    }

    [Test]
    public void AddProduct_AddsProductToInternalList()
    {
        var manager = new ProductManager();
        var product = new Product(1, "Pan", 200m, "Alimentos");

        manager.AddProduct(product);

        Assert.That(manager.Products.Count, Is.EqualTo(1));
        Assert.That(manager.Products.First(), Is.SameAs(product));
    }

    [Test]
    public void FindProductByName_ReturnsMatchingProduct()
    {
        var manager = new ProductManager();
        manager.AddProduct(new Product(1, "Teclado", 1000m, "Electrónica"));
        manager.AddProduct(new Product(2, "Leche", 50m, "Alimentos"));

        var found = manager.FindProductByName("Teclado");

        Assert.That(found, Is.Not.Null);
        Assert.That(found!.Name, Is.EqualTo("Teclado"));
    }

    [Test]
    public void FindProductByName_WhenDoesNotExist_ReturnsNull()
    {
        var manager = new ProductManager();
        manager.AddProduct(new Product(1, "Teclado", 1000m, "Electrónica"));

        var found = manager.FindProductByName("Monitor");

        Assert.That(found, Is.Null);
    }

    [TestCase(1000, "Electrónica", 1100)]
    [TestCase(1000, "Alimentos", 1050)]
    public void CalculateTotalPrice_ReturnsPricePlusApplicableTax(decimal basePrice, string category, decimal expected)
    {
        var manager = new ProductManager();
        var product = new Product(1, "Producto", basePrice, category);

        var total = manager.CalculateTotalPrice(product);

        Assert.That(total, Is.EqualTo(expected));
    }

    [Test]
    public void Product_RejectsNegativePrice()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "TV", -100m, "Electrónica"));
    }

    [Test]
    public void Product_RejectsInvalidCategory()
    {
        Assert.Throws<ArgumentException>(() => new Product(1, "TV", 100m, "Ropa"));
    }

    [Test]
    public void AddProduct_RejectsNegativePrice()
    {
        var manager = new ProductManager();
        var product = new Product(1, "TV", 100m, "Electrónica");

        Assert.Throws<ArgumentOutOfRangeException>(() => manager.AddProduct(new Product(2, "TV Negativa", -10m, "Electrónica")));
    }

    [Test]
    public void AddProduct_RejectsInvalidCategory()
    {
        var manager = new ProductManager();

        Assert.Throws<ArgumentException>(() => manager.AddProduct(new Product(1, "TV", 100m, "Ropa")));
    }
}
