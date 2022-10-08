namespace TowerDefense.Api.Models.Items
{
    public interface IItem
    {
        string Id { get; set; }
        int Price { get; set; }
        int Health { get; set; }
        int Demage { get; set; }
        bool CanBeAffectedByAttack { get; set; }
        ItemType ItemType { get; set; }

        IItem Clone();
    }
}
