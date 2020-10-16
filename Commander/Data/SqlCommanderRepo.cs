namespace Commander.Data
{
    using Commander.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext db;

        public SqlCommanderRepo(CommanderContext db)
        {
            this.db = db;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            this.db.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            this.db.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return this.db.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return this.db.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (this.db.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {            
        }
    }
}
