namespace Commander.Controllers
{
    using Commander.Data;
    using Commander.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    // api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo repository;

        public CommandsController(ICommanderRepo repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commands = this.repository.GetAllCommands();

            return Ok(commands);
        }

        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var currentCommand = this.repository.GetCommandById(id);

            return Ok(currentCommand);
        }
    }
}
