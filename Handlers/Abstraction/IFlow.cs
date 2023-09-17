namespace Handlers.Abstraction;

public interface IFlow
{
    object TriggerFlow(object request);
}