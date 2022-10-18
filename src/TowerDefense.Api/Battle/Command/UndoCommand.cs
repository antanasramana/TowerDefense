﻿using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Command
{
    public class UndoCommand : Command
    {
        private readonly CommandHandler _commandHandler;
        protected override bool canBeUndone => false;

        public UndoCommand(IPlayer player) : base(player)
        {
        }

        public override void Execute()
        {
            _commandHandler.Undo();
        }

        public override void Undo()
        {
            return;
        }
    }
}
