using Chain_Of_Responsibility.Interfaces;

abstract class AbstractHandler : IHandler
{
    private IHandler nextHandler;
    
    public IHandler SetNext(IHandler handler)
    {
        return this.nextHandler = handler;
    }

    public virtual object Handle(object request)
    {
        if (this.nextHandler != null)
        {
            return this.nextHandler.Handle(request);
        }

        return request;
    }
}

class HandlerA : AbstractHandler
{
    public override object Handle(object request)
    {
        Console.WriteLine("Handler A handling");
        return base.Handle(request);
    }
}

class HandlerB : AbstractHandler
{
    public override object Handle(object request)
    {
        Console.WriteLine("Handler B handling");
        return base.Handle(request);
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var handlerA = new HandlerA();
        var handlerB = new HandlerB();

        handlerA.SetNext(handlerB);
        
        Client(handlerA);
    }

    public static void Client(IHandler handler)
    {
        handler.Handle(null);
    }
}