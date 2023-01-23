using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Scaletronix.Server.Common.Controlling;

public abstract class ApiControllerBase : ControllerBase
{
    protected IMediator Mediator { get; }

    protected ApiControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }
}