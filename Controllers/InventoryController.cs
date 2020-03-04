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

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetOneItem(int id)
    {
      var item = await db.Items.FirstOrDefaultAsync(i => i.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

    [HttpGet("sku/{sku}")]
    public async Task<ActionResult<Item>> GetOneItemSku(string sku)
    {
      var item = await db.Items.FirstOrDefaultAsync(i => i.Sku == sku);
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


    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(Item item)
    {
      await db.Items.AddAsync(item);
      await db.SaveChangesAsync();
      return Ok(item);
    }

    [HttpPut]
    public async Task<ActionResult<Item>> UpdateItem(int id, Item newData)
    {
      newData.Id = id;
      db.Entry(newData).State = EntityState.Modified;
      await db.SaveChangesAsync();
      return Ok(newData);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItem(int id)
    {
      var item = await db.Items.FirstOrDefaultAsync(f => f.Id == id);
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