namespace Commander.Data
{
    using Commander.Models;
    using System.Collections.Generic;

    public class MockRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command
            {
                Id = 0,
                HowTo = "Do work",
                Line = "Move your ass",
                Platform = "Office"
            },
                new Command
            {
                Id = 1,
                HowTo = "Rest",
                Line = "Just chill",
                Platform = "Wherever you want!"
            },
        };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "Do work",
                Line = "Move your ass",
                Platform = "Office"
            };
        }
    }
}
