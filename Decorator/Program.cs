using Decorator.Interfaces;

class Context : IComponent
{
    public void DoOperation()
    {
        Console.WriteLine("Sending message on mail");
    }
}

class ComponentA : IComponent
{
    public IComponent Component { get; set; }

    public ComponentA(IComponent component)
    {
        Component = component;
    }

    public void DoOperation()
    {
        Component.DoOperation();
        Console.WriteLine("Sending message on Facebook");
    }
}

class ComponentB : IComponent
{
    public IComponent Component { get; set; }

    public ComponentB(IComponent component)
    {
        Component = component;
    }

    public void DoOperation()
    {
        Component.DoOperation();
        Console.WriteLine("Sending message on phone");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var context = new Context();
        var facebookNotifier = new ComponentA(context);
        var phoneNotifier = new ComponentB(facebookNotifier);
        phoneNotifier.DoOperation();
    }
}
