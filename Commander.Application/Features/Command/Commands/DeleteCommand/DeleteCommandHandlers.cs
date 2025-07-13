using MediatR;
using Commander.Domain.Models;
using AutoMapper;

namespace Commander.Application.Features.Command.Commands.DeleteCommand
{
    public class DeleteCommandHandlers : IRequestHandler<DeleteCommand, bool>
    {
        private readonly ICommandRepository _commandRepository;
        public DeleteCommandHandlers(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _commandRepository.DeleteAsync(request.Id);
            await _commandRepository.SaveChangesAsync();
            return true;
        }
    }
}
