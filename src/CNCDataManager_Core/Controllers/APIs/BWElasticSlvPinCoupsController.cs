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
    public class BWElasticSlvPinCoupsController : Controller
    {
        private CNCMachineData db;

        public BWElasticSlvPinCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/BWElasticSlvPinCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<BWElasticSlvPinCoup> GetBWElasticSlvPinCouplings()
        {
            return db.BWElasticSlvPinCouplings;
        }

        // GET: api/BWElasticSlvPinCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBWElasticSlvPinCoup(string id)
        {
            BWElasticSlvPinCoup bWElasticSlvPinCoup = await db.BWElasticSlvPinCouplings.FindAsync(id);
            if (bWElasticSlvPinCoup == null)
            {
                return NotFound();
            }

            return Ok(bWElasticSlvPinCoup);
        }

        // PUT: api/BWElasticSlvPinCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBWElasticSlvPinCoup(string id, BWElasticSlvPinCoup bWElasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bWElasticSlvPinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(bWElasticSlvPinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BWElasticSlvPinCoupExists(id))
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

        // POST: api/BWElasticSlvPinCoups
        [HttpPost]
        public async Task<IActionResult> PostBWElasticSlvPinCoup(BWElasticSlvPinCoup bWElasticSlvPinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BWElasticSlvPinCouplings.Add(bWElasticSlvPinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BWElasticSlvPinCoupExists(bWElasticSlvPinCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bWElasticSlvPinCoup.TypeID }, bWElasticSlvPinCoup);
        }

        // DELETE: api/BWElasticSlvPinCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBWElasticSlvPinCoup(string id)
        {
            BWElasticSlvPinCoup bWElasticSlvPinCoup = await db.BWElasticSlvPinCouplings.FindAsync(id);
            if (bWElasticSlvPinCoup == null)
            {
                return NotFound();
            }

            db.BWElasticSlvPinCouplings.Remove(bWElasticSlvPinCoup);
            await db.SaveChangesAsync();

            return Ok(bWElasticSlvPinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BWElasticSlvPinCoupExists(string id)
        {
            return db.BWElasticSlvPinCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}