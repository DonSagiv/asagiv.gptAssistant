using MediatR;
using asagiv.Domain.Core.Interfaces;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Requests;

public record SendGptRequest(IGptRequestModel Request)  : IRequest<IResult>;
