using Adapter.Interfaces;

class Adaptee
{
    public void DoOperation()
    {
        Console.WriteLine("Incompatible operation");
    }
}

class AdapterClient : ITarget
{
    private readonly Adaptee _adaptee;

    public AdapterClient(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void GetRequest()
    {
        Console.Write("Doing operation to execute - ");
        _adaptee.DoOperation();
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var adaptee = new Adaptee();
        var adapter = new AdapterClient(adaptee);
        adapter.GetRequest();
    }
}
