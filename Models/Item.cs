using System;
using System.Collections.Generic;

namespace Inventory.Models
{
  public class Item
  {
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public int NumberInStock { get; set; }
    public double Price { get; set; }
    public DateTime? DateOrdered { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }

  }
}