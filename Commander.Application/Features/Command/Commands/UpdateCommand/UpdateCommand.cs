using MediatR;
using Commander.Contracts.Dtos;

namespace Commander.Application.Features.Command.Commands.UpdateCommand
{
    public record UpdateCommand(int Id, string HowTo, string Line, string Platform) : IRequest<CommandResponseDto>;
}
