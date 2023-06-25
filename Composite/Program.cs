abstract class Composite
{
    public Composite _composite;

    public abstract void Operation();

    public virtual void Add(Composite _composite)
    {
        throw new Exception();
    }

    public virtual void Remove(Composite _composite)
    {
        throw new Exception();
    }

    public virtual bool IsComposite()
    {
        return true;
    }
}

class Component : Composite
{
    private List<Composite> _components = new();

    public override void Add(Composite _composite)
    {
        this._components.Add(_composite);
    }

    public override void Remove(Composite _composite)
    {
        this._components.Remove(_composite);
    }

    public override void Operation()
    {
        Console.WriteLine("Composite node doing operation");
        
        foreach (var component in this._components)
        {
            component.Operation();
        }
    }
}

class Leaf : Composite
{
    public override void Operation()
    {
        Console.WriteLine("Leaf node doing operation");
    }

    public override bool IsComposite()
    {
        return false;
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var tree = new Component();
        var branch1 = new Component();
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());
        var branch2 = new Component();
        branch2.Add(new Leaf());
        tree.Add(branch1);
        tree.Add(branch2);
        
        tree.Operation();
    }
}