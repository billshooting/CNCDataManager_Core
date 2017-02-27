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
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    public class SpurGearsController : Controller
    {
        private CNCMachineData db;

        public SpurGearsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SpurGears
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpurGear> GetSpurGears()
        {
            return db.SpurGears;
        }

        // GET: api/SpurGears/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpurGear(string id)
        {
            SpurGear spurGear = await db.SpurGears.FindAsync(id);
            if (spurGear == null)
            {
                return NotFound();
            }

            return Ok(spurGear);
        }

        // PUT: api/SpurGears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpurGear(string id, [FromBody] SpurGear spurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spurGear.TypeID)
            {
                return BadRequest();
            }

            db.Entry(spurGear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpurGearExists(id))
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

        // POST: api/SpurGears
        [HttpPost]
        public async Task<IActionResult> PostSpurGear([FromBody]SpurGear spurGear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpurGears.Add(spurGear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpurGearExists(spurGear.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spurGear.TypeID }, spurGear);
        }

        // DELETE: api/SpurGears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpurGear(string id)
        {
            SpurGear spurGear = await db.SpurGears.FindAsync(id);
            if (spurGear == null)
            {
                return NotFound();
            }

            db.SpurGears.Remove(spurGear);
            await db.SaveChangesAsync();

            return Ok(spurGear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpurGearExists(string id)
        {
            return db.SpurGears.Count(e => e.TypeID == id) > 0;
        }
    }
}