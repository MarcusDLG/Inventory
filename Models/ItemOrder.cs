namespace Inventory.Models
{
  public class ItemOrder
  {
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
  }
}