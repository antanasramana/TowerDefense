namespace TowerDefense.Api.GameLogic.Composite
{
    public class ExpressionComposite : ExpressionComponent
    {
        private List<ExpressionComponent> expressionList { get; set; } = new List<ExpressionComponent>();

        public void Execute(string playerName)
        {
            foreach (var item in expressionList)
            {
                item.Execute(playerName);
            }
        }

        public bool IsComposite()
        {
            return true;
        }

        public void Add(ExpressionComponent expressionComponent)
        {
            expressionList.Add(expressionComponent);
        }

        public void Remove(ExpressionComponent expressionComponent)
        {
            expressionList.Remove(expressionComponent);
        }

        public ExpressionComponent GetChild(int index)
        {
            return expressionList[index];
        }
    }
}
