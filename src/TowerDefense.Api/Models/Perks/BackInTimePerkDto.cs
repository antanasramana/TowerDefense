namespace TowerDefense.Api.Models.Perks
{
    public class BackInTimePerk : IPerk
    {
        public int Id { get; init; }
        public string Name => "Back in Time!";
    }
}
