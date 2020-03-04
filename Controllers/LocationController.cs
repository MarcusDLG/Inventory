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
  public class LocationController : ControllerBase
  {
    public DatabaseContext db = new DatabaseContext();

    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetAllLocations()
    {
      var allLocations = await db.Locations.OrderBy(n => n.Id).ToListAsync();
      if (allLocations == null)
      {
        return NotFound();
      }
      else
      {
        return allLocations;
      }

    }
    [HttpPost]
    public async Task<ActionResult<Location>> CreateItem(Location location)
    {
      await db.Locations.AddAsync(location);
      await db.SaveChangesAsync();
      return Ok(location);
    }

  }
}