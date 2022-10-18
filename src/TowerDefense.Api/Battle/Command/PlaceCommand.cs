using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class PlaceCommand : Command, IRevertable
    {
        public PlaceCommand(IPlayer player) : base(player)
        {
        }

        protected override bool canBeUndone => throw new NotImplementedException();

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
