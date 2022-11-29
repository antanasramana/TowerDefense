namespace TowerDefense.Api.GameLogic.Composite
{
    public class ExpressionComposite : IExpressionComponent
    {
        private List<IExpressionComponent> expressionList { get; set; } = new List<IExpressionComponent>();

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

        public void Add(IExpressionComponent expressionComponent)
        {
            expressionList.Add(expressionComponent);
        }

        public void Remove(IExpressionComponent expressionComponent)
        {
            expressionList.Remove(expressionComponent);
        }

        public IExpressionComponent GetChild(int index)
        {
            return expressionList[index];
        }
    }
}
