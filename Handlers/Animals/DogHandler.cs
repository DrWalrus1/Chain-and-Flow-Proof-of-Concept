﻿using Handlers.Abstraction;

namespace Handlers.Animals;

public class DogHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "MeatBall")
        {
            return $"Dog: I'll eat the {request.ToString()}.\n";
        }

        return base.Handle(request);
    }
}