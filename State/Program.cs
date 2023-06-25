abstract class State
{
    public Context _context;

    protected void SetContext(Context context)
    {
        this._context = context;
    }

    public abstract void DoOperation();
}

class Context
{
    private State _state = null;

    public Context(State state)
    {
        this.SetState(state);
        this._state._context = this;
    }

    public void SetState(State state)
    {
        this._state = state;
    }

    public void DoOperation()
    {
        this._state.DoOperation();
    }
}

class StateA : State
{
    public override void DoOperation()
    {
        Console.WriteLine("State A doing operation");
        this._context.SetState(new StateB());
    }
}

class StateB : State
{
    public override void DoOperation()
    {
        Console.WriteLine("State B doing operation");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var context = new Context(new StateA());
        
        context.DoOperation();
        context.DoOperation();
    }
}