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
    public class GearCoupsController : Controller
    {
        private CNCMachineData db;

        public GearCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/GearCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<GearCoup> GetGearCouplings()
        {
            return db.GearCouplings;
        }

        // GET: api/GearCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGearCoup(string id)
        {
            GearCoup gearCoup = await db.GearCouplings.FindAsync(id);
            if (gearCoup == null)
            {
                return NotFound();
            }

            return Ok(gearCoup);
        }

        // PUT: api/GearCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGearCoup(string id, GearCoup gearCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gearCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(gearCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GearCoupExists(id))
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

        // POST: api/GearCoups
        [HttpPost]
        public async Task<IActionResult> PostGearCoup(GearCoup gearCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GearCouplings.Add(gearCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GearCoupExists(gearCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gearCoup.TypeID }, gearCoup);
        }

        // DELETE: api/GearCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGearCoup(string id)
        {
            GearCoup gearCoup = await db.GearCouplings.FindAsync(id);
            if (gearCoup == null)
            {
                return NotFound();
            }

            db.GearCouplings.Remove(gearCoup);
            await db.SaveChangesAsync();

            return Ok(gearCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GearCoupExists(string id)
        {
            return db.GearCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}