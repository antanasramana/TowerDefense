namespace TowerDefense.Api.Models.Perks
{
    public class BackInTimePerkDto : IPerkDto
    {
        public int Id { get; init; }
        public string Name => "Back in Time!";
    }
}
