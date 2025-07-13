using MediatR;
using Commander.Domain.Models;
using Commander.Contracts.Dtos;
using AutoMapper;

namespace Commander.Application.Features.Command.Commands.UpdateCommand
{
    public class UpdateCommandHandlers : IRequestHandler<UpdateCommand, CommandResponseDto>
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;
        public UpdateCommandHandlers(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponseDto> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var command = await _commandRepository.FindByIdAsync(request.Id);
            if (command == null)
                throw new KeyNotFoundException("Command not found.");

            command.HowTo = request.HowTo;
            command.Line = request.Line;
            command.Platform = request.Platform;
            await _commandRepository.UpdateAsync(command);
            await _commandRepository.SaveChangesAsync();
            return _mapper.Map<CommandResponseDto>(command);
        }
    }
}
