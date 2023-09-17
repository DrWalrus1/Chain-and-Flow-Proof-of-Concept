using Handlers.Abstraction;

namespace Handlers.Flows;

public class MonkeySquirrelDogFlow : IFlow
{
    private IHandler HandlerFlow { get; set; }

    public MonkeySquirrelDogFlow(IHandler monkeyHandler, IHandler squirrelHandler, IHandler dogHandler)
    {
        HandlerFlow = monkeyHandler.SetNext(squirrelHandler).SetNext(dogHandler);
    }

    public object TriggerFlow(object request)
    {
        return HandlerFlow.Handle(request);
    }
}