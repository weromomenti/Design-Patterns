class Facade
{
    private readonly SubsystemA _subsystemA;

    private readonly SubsystemB _subsystemB;

    public Facade(SubsystemA subsystemA, SubsystemB subsystemB)
    {
        _subsystemA = subsystemA;
        _subsystemB = subsystemB;
    }

    public void DoOperation()
    {
        _subsystemA.FeatureA();
        _subsystemA.FeatureB();
        Console.WriteLine();
        _subsystemB.FeatureA();
        _subsystemB.FeatureB();
    }
}

internal class SubsystemA
{
    public void FeatureA()
    {
        Console.WriteLine("Subsystem A feature A");
    }

    public void FeatureB()
    {
        Console.WriteLine("Subsystem A feature B");
    }
}

internal class SubsystemB
{
    public void FeatureA()
    {
        Console.WriteLine("Subsystem B feature A");
    }

    public void FeatureB()
    {
        Console.WriteLine("Subsystem B feature B");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var subsystemA = new SubsystemA();
        var subsystemB = new SubsystemB();

        var facade = new Facade(subsystemA, subsystemB);

        facade.DoOperation();
    }
}
