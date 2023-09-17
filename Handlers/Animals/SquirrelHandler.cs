using Handlers.Abstraction;

namespace Handlers.Animals;

public class SquirrelHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Nut")
        {
            return $"Squirrel: I'll eat the {request.ToString()}.\n";
        }

        return base.Handle(request);
    }
}