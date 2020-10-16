namespace Commander.Data
{
    using Commander.Models;
    using System.Collections.Generic;

    public interface ICommanderRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int id);

        void CreateCommand(Command cmd);
    }
}
