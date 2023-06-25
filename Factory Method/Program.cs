using Factory_Method.Interfaces;

class CreatorA : ICreator
{
    public IProduct FactoryMethod()
    {
        return new ProductA();
    }

    public void DoOperation()
    {
        Console.WriteLine($"Doing some business stuff with the help of {FactoryMethod().Name}");
    }
}

class CreatorB : ICreator
{
    public IProduct FactoryMethod()
    {
        return new ProductB();
    }

    public void DoOperation()
    {
        Console.WriteLine($"Doing some business stuff with the help of {FactoryMethod().Name}");
    }
}


class ProductA : IProduct
{
    public string Name { get; } = "Product A";
}

class ProductB : IProduct
{
    public string Name { get; } = "Product B";
}

internal class Program
{
    public static void Main(string[] args)
    {
        Client(new CreatorA());
        Client(new CreatorB());

        var secondContext = new CreatorB();
        secondContext.DoOperation();
    }

    public static void Client(ICreator creator)
    {
        creator.DoOperation();
    }
}
