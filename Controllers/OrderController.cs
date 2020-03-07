using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    public DatabaseContext db = new DatabaseContext();

    // [HttpGet]
    // public async Task<ActionResult<List<Order>>> GetAllOrders()
    // {
    //   var allOrders = db.Orders.Include(n => n.ItemOrders).OrderBy(n => n.Id);
    //   if (allOrders == null)
    //   {
    //     return NotFound();
    //   }
    //   else
    //   {
    //     return Ok(await allOrders.ToListAsync());
    //   }
    // }

    [HttpGet]
    public ActionResult GetAllOrdersss()
    {
      return new ContentResult()
      {
        Content = JsonConvert.SerializeObject(db.Orders.Include(n => n.ItemOrders).OrderBy(n => n.Id),
        new JsonSerializerSettings
        {
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }),
        ContentType = "application/json",
        StatusCode = 200
      };
    }


    [HttpPost]
    public async Task<ActionResult<List<Order>>> PostOrder(Order newData)
    {
      // var itemOrder = new ItemOrder();

      // newData.ItemOrders.Add(itemOrder);
      await db.Orders.AddAsync(newData);
      await db.SaveChangesAsync();
      newData.ItemOrders = null;
      return Ok(newData);
    }



  }
}
