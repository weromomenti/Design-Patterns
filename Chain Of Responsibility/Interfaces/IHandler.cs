namespace Chain_Of_Responsibility.Interfaces;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
    object Handle(object request);
}