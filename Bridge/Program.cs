// See https://aka.ms/new-console-template for more information

using Bridge.Interfaces;

class Abstraction
{
    private  readonly IInterface _interface;

    public Abstraction(IInterface @interface)
    {
        this._interface = @interface;
    }

    public virtual void DelegateOperation()
    {
        Console.WriteLine("Doing operation");
        this._interface.DoOperation();
    }
}

class AbstractionExtension : Abstraction
{
    public AbstractionExtension(IInterface @interface) : base(@interface)
    {
        
    }

    public override void DelegateOperation()
    {
        Console.WriteLine("Some extended operation");
        base.DelegateOperation();
    }
}

class InterfaceA : IInterface
{
    public void DoOperation()
    {
        Console.WriteLine("Doing some operation from interface A");
    }
}

class InterfaceB : IInterface
{
    public void DoOperation()
    {
        Console.WriteLine("Doing some operation from interface B");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Abstraction abstraction;
        var interfaceA = new InterfaceA();
        var interfaceB = new InterfaceB();

        abstraction = new Abstraction(interfaceA);
        abstraction.DelegateOperation();

        abstraction = new AbstractionExtension(interfaceB);
        abstraction.DelegateOperation();
    }
}
