using asagiv.Appl.gptAssistant.Requests;
using asagiv.Domain.Core.Interfaces;
using asagiv.Domain.Core.Models;
using MediatR;

namespace asagiv.Appl.gptAssistant.Handlers;

internal class SendGptRequestHandler : IRequestHandler<SendGptRequest, IResult>
{
    public Task<IResult> Handle(SendGptRequest request, CancellationToken cancellationToken)
    {
        return Result.SuccessAsync();
    }
}
