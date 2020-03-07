using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {
    public DatabaseContext db = new DatabaseContext();

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAllItems()
    {
      var allItems = await db.Items.OrderBy(n => n.Name).ToListAsync();
      if (allItems == null)
      {
        return NotFound();
      }
      else
      {
        return allItems;
      }

    }

    [HttpGet("location/{locationId}")]
    public async Task<ActionResult<List<Item>>> GetAllItemsByLocation(int locationId)
    {
      var allItems = db.Items.Where(n => n.LocationId == locationId);
      if (allItems == null)
      {
        return NotFound();
      }
      else
      {
        return await allItems.ToListAsync();
      }

    }

    [HttpGet("{id}/{locationId}")]
    public async Task<ActionResult<Item>> GetOneItem(int id, int locationId)
    {
      var item = await db.Items.FirstOrDefaultAsync(i => i.Id == id && i.LocationId == locationId);
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

    [HttpGet("sku/{sku}")]
    public async Task<ActionResult<Item>> GetOneItemSku(string sku)
    {
      var item = await db.Items.Where(i => i.Sku == sku).ToListAsync();
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

    [HttpGet("Stock")]
    public async Task<ActionResult<Item>> GetOutOfStockedItems()
    {
      var item = await db.Items.Where(i => i.NumberInStock == 0).ToListAsync();
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

    [HttpGet("stock/{locationId}")]
    public async Task<ActionResult<Item>> GetOutOfStockLocation(int locationId)
    {
      var item = await db.Items.Where(i => i.NumberInStock == 0 && i.LocationId == locationId).ToListAsync();
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);

    }



    [HttpPost("{locationId}")]
    public async Task<ActionResult<Item>> CreateItemByLocation(int locationId, Item item)
    {
      item.LocationId = locationId;
      await db.Items.AddAsync(item);
      await db.SaveChangesAsync();
      return Ok(item);
    }

    [HttpPost("{locationId}/multiple")]
    public List<Item> AddManyItems(List<Item> items)
    {
      db.Items.AddRange(items);
      db.SaveChanges();
      return items;
    }

    [HttpPut("{id}/{locationId}")]
    public async Task<ActionResult<Item>> UpdateItem(int id, int locationId, Item newData)
    {
      newData.Id = id;
      newData.LocationId = locationId;
      db.Entry(newData).State = EntityState.Modified;
      await db.SaveChangesAsync();
      return Ok(newData);
    }

    [HttpDelete("{id}/{locationId}")]
    public async Task<ActionResult> DeleteItem(int id, int locationId)
    {
      var item = await db.Items.FirstOrDefaultAsync(f => f.Id == id && f.LocationId == locationId);
      if (item == null)
      {
        return NotFound();
      }
      db.Items.Remove(item);
      await db.SaveChangesAsync();
      return Ok();
    }
  }
}