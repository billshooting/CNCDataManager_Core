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
    public class OldhamCoupsController : Controller
    {
        private CNCMachineData db;

        public OldhamCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/OldhamCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<OldhamCoup> GetOldhamCouplings()
        {
            return db.OldhamCouplings;
        }

        // GET: api/OldhamCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOldhamCoup(string id)
        {
            OldhamCoup oldhamCoup = await db.OldhamCouplings.FindAsync(id);
            if (oldhamCoup == null)
            {
                return NotFound();
            }

            return Ok(oldhamCoup);
        }

        // PUT: api/OldhamCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOldhamCoup(string id, [FromBody] OldhamCoup oldhamCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oldhamCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(oldhamCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OldhamCoupExists(id))
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

        // POST: api/OldhamCoups
        [HttpPost]
        public async Task<IActionResult> PostOldhamCoup([FromBody] OldhamCoup oldhamCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OldhamCouplings.Add(oldhamCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OldhamCoupExists(oldhamCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oldhamCoup.TypeID }, oldhamCoup);
        }

        // DELETE: api/OldhamCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOldhamCoup(string id)
        {
            OldhamCoup oldhamCoup = await db.OldhamCouplings.FindAsync(id);
            if (oldhamCoup == null)
            {
                return NotFound();
            }

            db.OldhamCouplings.Remove(oldhamCoup);
            await db.SaveChangesAsync();

            return Ok(oldhamCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OldhamCoupExists(string id)
        {
            return db.OldhamCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}
