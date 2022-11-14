using TowerDefense.Api.Models.Items;

namespace TowerDefense.Api.GameLogic.Interpreter
{
    public class ItemTypeExpression : IAbstractExpression
    {
        public ItemType ItemType { get; set; }

        public bool Interpret(List<string> words)
        {
            string word = words.First();

            bool result = Enum.TryParse(word, out ItemType type);


            if (!result)
            {
                return false;
            }

            if (type == ItemType.Placeholder)
            {
                return false;
            }

            ItemType = type;
            return true;
        }
    }
}
