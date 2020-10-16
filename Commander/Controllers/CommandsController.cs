namespace Commander.Controllers
{
    using AutoMapper;
    using Commander.Data;
    using Commander.Dtos;
    using Commander.Models;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    // api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo repository;
        private readonly IMapper mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = this.repository.GetAllCommands();

            return Ok(this.mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var currentCommand = this.repository.GetCommandById(id);

            if (currentCommand != null)
            {
                return Ok(this.mapper.Map<CommandReadDto>(currentCommand));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmd)
        {
            var cmdModel = this.mapper.Map<Command>(cmd);
            this.repository.CreateCommand(cmdModel);
            this.repository.SaveChanges();

            var readDto = this.mapper.Map<CommandReadDto>(cmdModel);

            return CreatedAtRoute(nameof(GetCommandById), new { readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var cmdModelFromRepo = this.repository.GetCommandById(id);

            if (cmdModelFromRepo == null)
            {
                return NotFound();
            }

            this.mapper.Map(updateDto, cmdModelFromRepo);

            this.repository.UpdateCommand(cmdModelFromRepo);
            this.repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patch)
        {
            var cmdModelFromRepo = this.repository.GetCommandById(id);

            if (cmdModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = this.mapper.Map<CommandUpdateDto>(cmdModelFromRepo);
            patch.ApplyTo(commandToPatch, ModelState);

            if (TryValidateModel(commandToPatch) == false)
            {
                return ValidationProblem(ModelState);
            }

            this.mapper.Map(commandToPatch, cmdModelFromRepo);

            this.repository.UpdateCommand(cmdModelFromRepo);
            this.repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var cmdModelFromRepo = this.repository.GetCommandById(id);

            if (cmdModelFromRepo == null)
            {
                return NotFound();
            }

            this.repository.DeleteCommand(cmdModelFromRepo);
            this.repository.SaveChanges();

            return NoContent();
        }
    }
}
