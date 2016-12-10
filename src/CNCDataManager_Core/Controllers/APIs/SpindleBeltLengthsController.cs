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
    public class SpindleBeltLengthsController : Controller
    {
        private CNCMachineData db;

        public SpindleBeltLengthsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SpindleBeltLengths
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SpindleBeltLength> GetSpindleBeltLengths()
        {
            return db.SpindleBeltLengths;
        }

        // GET: api/SpindleBeltLengths/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpindleBeltLength(int id)
        {
            SpindleBeltLength spindleBeltLength = await db.SpindleBeltLengths.FindAsync(id);
            if (spindleBeltLength == null)
            {
                return NotFound();
            }

            return Ok(spindleBeltLength);
        }

        // PUT: api/SpindleBeltLengths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpindleBeltLength(int id, SpindleBeltLength spindleBeltLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spindleBeltLength.LengthID)
            {
                return BadRequest();
            }

            db.Entry(spindleBeltLength).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpindleBeltLengthExists(id))
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

        // POST: api/SpindleBeltLengths
        [HttpPost]
        public async Task<IActionResult> PostSpindleBeltLength(SpindleBeltLength spindleBeltLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SpindleBeltLengths.Add(spindleBeltLength);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpindleBeltLengthExists(spindleBeltLength.LengthID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spindleBeltLength.LengthID }, spindleBeltLength);
        }

        // DELETE: api/SpindleBeltLengths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpindleBeltLength(int id)
        {
            SpindleBeltLength spindleBeltLength = await db.SpindleBeltLengths.FindAsync(id);
            if (spindleBeltLength == null)
            {
                return NotFound();
            }

            db.SpindleBeltLengths.Remove(spindleBeltLength);
            await db.SaveChangesAsync();

            return Ok(spindleBeltLength);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpindleBeltLengthExists(int id)
        {
            return db.SpindleBeltLengths.Count(e => e.LengthID == id) > 0;
        }
    }
}