using System;
using System.Collections.Generic;

namespace Inventory.Models
{
  public class Order
  {
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string CustomerName { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public List<ItemOrder> ItemOrders { get; set; } = new List<ItemOrder>();
  }
}