
using Observer_Pattern.Interfaces;

class Observable : ISubject
{
    public readonly List<IObject> Observers = new();
    public int State { get; }

    public void DoBusinessLogic()
    {
        Console.WriteLine("Doing some business operation");
        Notify();
    }


    public void Subscribe(IObject observer)
    {
        Observers.Add(observer);
        observer.Subject = this;
    }

    public void Unsubscribe(IObject observer)
    {
        Observers.Remove(observer);
        observer.Subject = null;
    }

    public void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update();
        }
    }
}

public class Observer : IObject
{
    public ISubject Subject { get; set; }

    public void Update()
    {
        Console.WriteLine($"Observer updated. state is {Subject.State}");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var observable = new Observable();
        var observerA = new Observer();
        var observerB = new Observer();

        observable.Subscribe(observerA);
        observable.Subscribe(observerB);

        observable.DoBusinessLogic();
    }
}