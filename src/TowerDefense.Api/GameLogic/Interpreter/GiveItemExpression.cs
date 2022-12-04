using TowerDefense.Api.GameLogic.Commands;

namespace TowerDefense.Api.GameLogic.Interpreter
{
    public class GiveItemExpression : ICommandExpression
    {
        public NumberExpression NumberExpression { get; set; }
        public ItemTypeExpression ItemTypeExpression { get; set; }

        public ICommand Evaluate()
        {
            return new GiveItemCommand(ItemTypeExpression.ItemType, NumberExpression.Amount);
        }

        public bool Interpret(List<string> words)
        {
            if (words[0] != "giveItem")
            {
                return false;
            }

            NumberExpression = new NumberExpression();
            ItemTypeExpression = new ItemTypeExpression();

            if (words.Count < 2)
            {
                return false;
            }

            bool result = ItemTypeExpression.Interpret(words.GetRange(1, words.Count - 1)) && 
                          NumberExpression.Interpret(words.GetRange(2, words.Count - 2));

            return result;
        }
    }
}
