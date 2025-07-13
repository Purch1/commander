using MediatR;
using AutoMapper;
using Commander.Application.Features.Command.Commands;
using Commander.Contracts.Dtos;
using Commander.Domain.Models;

public class CreateCommandHandlers(ICommandRepository commandRepository, IMapper mapper
): IRequestHandler<CreateCommand, CommandResponseDto>
{

    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;
    public async Task<CommandResponseDto> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        if (!await commandRepository.IsTitleUniqueAsync(request.HowTo))
        {
            throw new InvalidOperationException("Command title must be unique.");
        }

        var command = _mapper.Map<Command>(request);
        await _commandRepository.InsertAsync(command);
        await _commandRepository.SaveChangesAsync();

        return _mapper.Map<CommandResponseDto>(command);
    }
}