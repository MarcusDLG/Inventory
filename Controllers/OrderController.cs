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
  public class OrderController : ControllerBase
  {
    public DatabaseContext db = new DatabaseContext();

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
      var allOrders = db.Orders.OrderBy(n => n.Id);
      if (allOrders == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(await allOrders.ToListAsync());
      }

    }

    [HttpPost("{locationId}/{orderNumber}/{itemId}")]
    public async Task<ActionResult<List<Order>>> PostOrder(int locationId, int ordernumber, int itemId, Order newData)
    {
      newData.LocationId = locationId;
      newData.OrderNumber = ordernumber;
      await db.Orders.AddAsync(newData);
      await db.SaveChangesAsync();

      var itemOrder = new ItemOrder
      {
        OrderId = newData.Id,
        ItemId = itemId
      };
      await db.ItemOrders.AddAsync(itemOrder);
      return Ok(newData);
    }



  }
}