using NationalPark.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NationalPark.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RegionsController : ControllerBase
  {
    private readonly NationalParkContext _db;

    public RegionsController(NationalParkContext db)
    {
      _db = db;
    }

    // GET: api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Region>> GetRegion(int id)
    {
      var region = await _db.Regions.FindAsync(id);

      if (region == null)
      {
          return NotFound();
      }

      return region;
    }

    // GET api/regions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Region>>> Get(string name)
    {
      var query = _db.Regions.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      return await _db.Regions.ToListAsync();
    }

    // POST api/regions
    [HttpPost]
    public async Task<ActionResult<Region>> Post(Region region)
    {
      _db.Regions.Add(region);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetRegion), new { id = region.RegionId }, region);
    }

    // PUT: api/regions/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Region region)
    {
      if (id != region.RegionId)
      {
        return BadRequest();
      }

      _db.Entry(region).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RegionExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/regions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegion(int id)
    {
      var region = await _db.Regions.FindAsync(id);
      if (region == null)
      {
        return NotFound();
      }

      _db.Regions.Remove(region);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool RegionExists(int id)
    {
      return _db.Regions.Any(e => e.RegionId == id);
    }
  }
}
  