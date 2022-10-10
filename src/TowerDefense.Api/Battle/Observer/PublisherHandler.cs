using TowerDefense.Api.Battle.Grid;
using TowerDefense.Api.Models.Items;
using TowerDefense.Api.Models.Player;

namespace TowerDefense.Api.Battle.Observer
{
    public interface IPublisherHandler
    {
        void AddSubscriberToPublisher(int playerId, GridItem gridItemSubscriber);
    }

    public class PublisherHandler : IPublisherHandler
    {
        private readonly GameState _gameState;

        public PublisherHandler()
        {
            _gameState = GameState.Instance;
        }

        public void AddSubscriberToPublisher(int playerId, GridItem gridItemSubscriber)
        {
            var isItemInvalid = gridItemSubscriber.ItemType is ItemType.Blank or ItemType.Placeholder;

            if (isItemInvalid) return;

            switch (playerId)
            {
                case 0:
                    _gameState.GridPublishers[1].Attach(gridItemSubscriber);
                    break;

                case 1:
                    _gameState.GridPublishers[0].Attach(gridItemSubscriber);
                    break;
            }
        }
    }
}
