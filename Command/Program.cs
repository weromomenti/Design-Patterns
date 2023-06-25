using Command.Interfaces;

class SimpleCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Executing simple operation");
    }
}

class ComplexCommand : ICommand
{
    private readonly Receiver _receiver;

    public ComplexCommand(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        Console.WriteLine("Executing complex operation");
        _receiver.OperationA();
        _receiver.OperationB();
    }
}

class Receiver
{
    public void OperationA()
    {
        Console.WriteLine("Receiver executing operation A");
    }

    public void OperationB()
    {
        Console.WriteLine("Receiver executing operation B");
    }
}

class Invoker
{
    public Stack<ICommand> CommandHistory = new Stack<ICommand>();

    public ICommand OnStart { get; set; }

    public ICommand OnFinish { get; set; }

    public void DoOperation()
    {
        if (OnStart != null)
        {
            OnStart.Execute();
            CommandHistory.Push(OnStart);
        }

        Console.WriteLine("Some operation after start");

        if (OnFinish != null)
        {
            OnFinish.Execute();
            CommandHistory.Push(OnFinish);
        }
    }

    public void GetHistory()
    {
        foreach (var command in CommandHistory)
        {
            Console.WriteLine(command);
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var simpleCommand = new SimpleCommand();
        var complexCommand = new ComplexCommand(new Receiver());

        var invoker = new Invoker
        {
            OnStart = simpleCommand,
            OnFinish = complexCommand
        };

        invoker.DoOperation();
    }
}
