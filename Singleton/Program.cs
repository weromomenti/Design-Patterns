public sealed class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new();
    private Singleton()
    {
        
    }

    public static Singleton GetInstance()
    {
        lock (_lock)
        {
            return _instance ??= new Singleton();
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var instance1 = Singleton.GetInstance();
        var instance2 = Singleton.GetInstance();

        if (instance1 == instance2)
        {
            Console.WriteLine("They are the same");
        }
    }
}
