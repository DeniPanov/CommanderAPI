namespace Commander.Data
{
    using Commander.Models;
    using System.Collections.Generic;

    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);
    }
}
