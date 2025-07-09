using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan" },
                new Command{Id=1, HowTo="Fish and Milk", Line="Boil fish", Platform="Laptop" },
                new Command{Id=2, HowTo="Rice and beans", Line="Monitor", Platform="Table is clean" },
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan" };
        }
    }
}