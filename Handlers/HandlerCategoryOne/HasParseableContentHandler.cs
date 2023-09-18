using Handlers.Abstraction;

namespace Handlers.Animals;

public class HasParseableContentHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request is IHasParseableContent)
        {
            return $"Monkey: I'll eat the {request.ToString()}.\n";
        }

        return base.Handle(request);
    }
}