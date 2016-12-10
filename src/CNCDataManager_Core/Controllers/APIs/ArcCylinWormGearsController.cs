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
    //[ApiAuthorize]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class ArcCylinWormGearsController : Controller
    {
        private CNCMachineData db;

        public ArcCylinWormGearsController(CNCMachineData database)
        {
            db = database;
        }

        // GET: api/ArcCylinWormGears
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<ArcCylinWormGear> GetArcCylinWormGears()
        {
            return db.ArcCylinWormGears;
        }

        // GET: api/ArcCylinWormGears/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArcCylinWormGear(string id)
        {
            ArcCylinWormGear arcCylinWormGear = await db.ArcCylinWormGears.FindAsync(id);
            if (arcCylinWormGear == null)
            {
                return NotFound();
            }

            return Ok(arcCylinWormGear);
        }

        // PUT: api/ArcCylinWormGears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArcCylinWormGear(string id, ArcCylinWormGear arcCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arcCylinWormGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(arcCylinWormGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArcCylinWormGearExists(id))
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

        // POST: api/ArcCylinWormGears
        [HttpPost]
        public async Task<IActionResult> PostArcCylinWormGear(ArcCylinWormGear arcCylinWormGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArcCylinWormGears.Add(arcCylinWormGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArcCylinWormGearExists(arcCylinWormGear.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = arcCylinWormGear.TypeID }, arcCylinWormGear);
        }

        // DELETE: api/ArcCylinWormGears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArcCylinWormGear(string id)
        {
            ArcCylinWormGear arcCylinWormGear = await db.ArcCylinWormGears.FindAsync(id);
            if (arcCylinWormGear == null)
            {
                return NotFound();
            }

            db.ArcCylinWormGears.Remove(arcCylinWormGear);
            await db.SaveChangesAsync();

            return Ok(arcCylinWormGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArcCylinWormGearExists(string id)
        {
            return db.ArcCylinWormGears.Count(e => e.TypeID == id) > 0;
        }
    }
}