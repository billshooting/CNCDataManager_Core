using CNCDataManager.Models.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers.APIs
{
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class StraightBevelGearsController : Controller
    {
        private CNCMachineData db;

        StraightBevelGearsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/StraightBevelGears
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<StraightBevelGear> GetStraightBevelGears()
        {
            return db.StraightBevelGears;
        }

        // GET: api/StraightBevelGears/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStraightBevelGear(string id)
        {
            StraightBevelGear straightBevelGear = await db.StraightBevelGears.FindAsync(id);
            if (straightBevelGear == null)
            {
                return NotFound();
            }

            return Ok(straightBevelGear);
        }

        // PUT: api/StraightBevelGears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStraightBevelGear(string id, [FromBody] StraightBevelGear straightBevelGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != straightBevelGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(straightBevelGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StraightBevelGearExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        // POST: api/StraightBevelGears
        [HttpPost]
        public async Task<IActionResult> PostStraightBevelGear([FromBody] StraightBevelGear straightBevelGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StraightBevelGears.Add(straightBevelGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StraightBevelGearExists(straightBevelGear.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = straightBevelGear.TypeID }, straightBevelGear);
        }

        // DELETE: api/StraightBevelGears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStraightBevelGear(string id)
        {
            StraightBevelGear straightBevelGear = await db.StraightBevelGears.FindAsync(id);
            if (straightBevelGear == null)
            {
                return NotFound();
            }

            db.StraightBevelGears.Remove(straightBevelGear);
            await db.SaveChangesAsync();

            return Ok(straightBevelGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StraightBevelGearExists(string id)
        {
            return db.StraightBevelGears.Count(e => e.TypeID == id) > 0;
        }
    }
}