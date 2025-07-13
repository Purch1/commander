
using MediatR;
using Commander.Contracts.Dtos;

namespace Commander.Application.Features.Command.Commands;

public sealed record CreateCommand(
        string HowTo,
        string Line,
        string Platform

): IRequest<CommandResponseDto>;

