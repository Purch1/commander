using Commander.Domain.Models;
using Commander.Domain.Repositories;

namespace Commander.API.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        private readonly List<Command> _commands = new List<Command>
        {
            new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
            new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "knife & chopping board" },
            new Command { Id = 2, HowTo = "Make cup of tea", Line = "Place teabag in cup", Platform = "Kettle & cup" }
        };

        public void CreateCommand(Command cmd)
        {
            cmd.Id = _commands.Count;
            _commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            _commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commands;
        }

        public Command GetCommandById(int id)
        {
            return _commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateCommand(Command cmd)
        {
            // Nothing to do here
        }
    }
}
