// See https://aka.ms/new-console-template for more information
abstract class AbstractTemplate
{
    public void TemplateMethod()
    {
        this.BaseMethod1();
        this.RequiredMethod1();
        this.Hook1();
        this.BaseMethod2();
        this.RequiredMethod2();
        this.Hook2();
    }

    protected abstract void RequiredMethod1();

    protected abstract void RequiredMethod2();

    private void BaseMethod1()
    {
        Console.WriteLine("Base method 1");
    }

    private void BaseMethod2()
    {
        Console.WriteLine("Base method 2");
    }

    protected virtual void Hook1()
    {
    }

    protected virtual void Hook2()
    {   
    }
}

class TemplateImplementationA : AbstractTemplate
{
    protected override void RequiredMethod1()
    {
        Console.WriteLine("Implementation of required method 1 by implementer A");
    }

    protected override void RequiredMethod2()
    {
        Console.WriteLine("Implementation of required method 2 by implementer A");
    }
}

class TemplateImplementationB : AbstractTemplate
{
    protected override void RequiredMethod1()
    {
        Console.WriteLine("Implementation of required method 1 by implementer B");
    }

    protected override void RequiredMethod2()
    {
        Console.WriteLine("Implementation of required method 2 by implementer B");
    }

    protected override void Hook2()
    {
        Console.WriteLine("Implementation of Hook 2 by implementer B");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var implementerA = new TemplateImplementationA();
        var implementerB = new TemplateImplementationB();
        
        implementerA.TemplateMethod();
        implementerB.TemplateMethod();
    }
}