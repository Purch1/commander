using MediatR;
using Commander.Contracts.Dtos;

namespace Commander.Application.Features.Command.Commands.GetCommandById
{
    public record GetCommandById(int Id) : IRequest<CommandResponseDto>;
}
