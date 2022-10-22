using TowerDefense.Api.Battle.Command;

namespace TowerDefense.Api.Battle.Handlers
{
    public interface ICommandHandler
    {
        void ExecuteCommandForPlayer(string playerName, Command.Command command);
    }
    public class CommandHandler : ICommandHandler
    {
        private readonly IPlayerHandler _playerHandler;

        public CommandHandler (IPlayerHandler playerHandler)
        {
            _playerHandler = playerHandler;
        }

        public void ExecuteCommandForPlayer(string playerName, Command.Command command)
        {
            var player = _playerHandler.GetPlayer(playerName);
            player.CommandExecutor.Execute(command);
        }
    }
}
