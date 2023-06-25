using Proxy.Interfaces;

class RealInstance : ISubject
{
    public void Execute()
    {
        Console.WriteLine("Execution from real instance");
    }
}

class ProxyInstance : ISubject
{
    private readonly RealInstance realInstance;

    public ProxyInstance(RealInstance realInstance)
    {
        this.realInstance = realInstance;
    }

    public void Execute()
    {
        if (!this.CheckAccess())
        {
            return;
        }
        realInstance.Execute();
        this.LogAccess();
    }

    private bool CheckAccess()
    {
        Console.WriteLine("Running code for checking access");
        return true;
    }

    private void LogAccess()
    {
        Console.WriteLine("Logging Access");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var realInstance = new RealInstance();
        var proxyInstance = new ProxyInstance(realInstance);

        Client(proxyInstance);
    }

    public static void Client(ISubject subject)
    {
        subject.Execute();
    }
}
