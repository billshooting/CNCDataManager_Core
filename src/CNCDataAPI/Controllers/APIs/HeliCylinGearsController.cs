using CNCDataManager.Controllers.Internals;
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
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class HeliCylinGearsController : Controller
    {
        private CNCMachineData db;

        public HeliCylinGearsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/HeliCylinGears
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<HeliCylinGear> GetHeliCylinGears()
        {
            return db.HeliCylinGears;
        }

        // GET: api/HeliCylinGears/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeliCylinGear(string id)
        {
            HeliCylinGear heliCylinGear = await db.HeliCylinGears.FindAsync(id);
            if (heliCylinGear == null)
            {
                return NotFound();
            }

            return Ok(heliCylinGear);
        }

        // PUT: api/HeliCylinGears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeliCylinGear(string id, [FromBody] HeliCylinGear heliCylinGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heliCylinGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(heliCylinGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeliCylinGearExists(id))
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

        // POST: api/HeliCylinGears
        [HttpPost]
        public async Task<IActionResult> PostHeliCylinGear([FromBody] HeliCylinGear heliCylinGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HeliCylinGears.Add(heliCylinGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeliCylinGearExists(heliCylinGear.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = heliCylinGear.TypeID }, heliCylinGear);
        }

        // DELETE: api/HeliCylinGears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeliCylinGear(string id)
        {
            HeliCylinGear heliCylinGear = await db.HeliCylinGears.FindAsync(id);
            if (heliCylinGear == null)
            {
                return NotFound();
            }

            db.HeliCylinGears.Remove(heliCylinGear);
            await db.SaveChangesAsync();

            return Ok(heliCylinGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeliCylinGearExists(string id)
        {
            return db.HeliCylinGears.Count(e => e.TypeID == id) > 0;
        }
    }
}