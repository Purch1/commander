using System.Collections.Generic;
using AutoMapper;
using Commander.Contracts.Dtos;
using Commander.Domain.Models;
using Commander.Domain.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
                return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute("GetCommandById", new { id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var existingCommand = _repository.GetCommandById(id);
            if (existingCommand == null)
                return NotFound();

            _mapper.Map(commandUpdateDto, existingCommand);
            _repository.UpdateCommand(existingCommand);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var existingCommand = _repository.GetCommandById(id);
            if (existingCommand == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(existingCommand);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, existingCommand);
            _repository.UpdateCommand(existingCommand);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var existingCommand = _repository.GetCommandById(id);
            if (existingCommand == null)
                return NotFound();

            _repository.DeleteCommand(existingCommand);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}