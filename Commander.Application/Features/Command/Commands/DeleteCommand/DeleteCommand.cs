using MediatR;

namespace Commander.Application.Features.Command.Commands.DeleteCommand
{
    public record DeleteCommand(int Id) : IRequest<bool>;
}
