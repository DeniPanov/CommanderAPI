namespace Commander.Controllers
{
    using AutoMapper;
    using Commander.Data;
    using Commander.Dtos;
    using Commander.Models;
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

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var currentCommand = this.repository.GetCommandById(id);

            if (currentCommand != null)
            {
                return Ok(this.mapper.Map<CommandReadDto>(currentCommand));
            }

            return NotFound();
        }
    }
}
