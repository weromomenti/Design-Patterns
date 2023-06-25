using System.Reflection;
using Abstract_Method.Interfaces;

class AbstractFactoryA : IFactory
{
    public IProductA CreateProductA()
    {
        var product = new ProductA1();
        Console.WriteLine($"Creating {product.Name}");
        return product;
    }

    public IProductB CreateProductB()
    {
        var product = new ProductB1();
        Console.WriteLine($"Creating {product.Name}");
        return product;
    }
}

class AbstractFactoryB : IFactory
{
    public IProductA CreateProductA()
    {
        var product = new ProductA2();
        Console.WriteLine($"Creating {product.Name}");
        return product;
    }

    public IProductB CreateProductB()
    {
        var product = new ProductB2();
        Console.WriteLine($"Creating {product.Name}");
        return product;
    }
}

internal class ProductA1 : IProductA
{
    public string Name { get; } = "ProductA1";
}

internal class ProductB1 : IProductB
{
    public string Name { get; } = "ProductB1";
}

internal class ProductA2 : IProductA
{
    public string Name { get; } = "ProductA2";
}

internal class ProductB2 : IProductB
{
    public string Name { get; } = "ProductB2";
}

internal class Program
{
    public static void Main(string[] args)
    {
        Client(new AbstractFactoryA());
        Client(new AbstractFactoryB());
    }

    public static void Client(IFactory factory)
    {
        factory.CreateProductA();
        factory.CreateProductB();
    }
}
