namespace TowerDefense.Api.Contracts.Command
{
    public class InterpretCommandRequest
    {
        public string PlayerName { get; set; }
        public string CommandText { get; set; }
    }
}
