namespace TowerDefense.Api.Contracts.Player
{
    public class GetPlayerInfoResponse
    {
        public string PlayerName { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Money { get; set; }
    }
}
