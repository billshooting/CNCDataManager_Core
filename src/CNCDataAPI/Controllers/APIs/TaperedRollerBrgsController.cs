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
    public class TaperedRollerBrgsController : Controller
    {
        private CNCMachineData db;

        public TaperedRollerBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/TaperedRollerBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<TaperedRollerBrg> GetTaperedRollerBearings()
        {
            return db.TaperedRollerBearings;
        }

        // GET: api/TaperedRollerBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaperedRollerBrg(string id)
        {
            TaperedRollerBrg taperedRollerBrg = await db.TaperedRollerBearings.FindAsync(id);
            if (taperedRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(taperedRollerBrg);
        }

        // PUT: api/TaperedRollerBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaperedRollerBrg(string id, [FromBody] TaperedRollerBrg taperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taperedRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(taperedRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaperedRollerBrgExists(id))
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

        // POST: api/TaperedRollerBrgs
        [HttpPost]
        public async Task<IActionResult> PostTaperedRollerBrg([FromBody]TaperedRollerBrg taperedRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaperedRollerBearings.Add(taperedRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaperedRollerBrgExists(taperedRollerBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taperedRollerBrg.TypeID }, taperedRollerBrg);
        }

        // DELETE: api/TaperedRollerBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaperedRollerBrg(string id)
        {
            TaperedRollerBrg taperedRollerBrg = await db.TaperedRollerBearings.FindAsync(id);
            if (taperedRollerBrg == null)
            {
                return NotFound();
            }

            db.TaperedRollerBearings.Remove(taperedRollerBrg);
            await db.SaveChangesAsync();

            return Ok(taperedRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaperedRollerBrgExists(string id)
        {
            return db.TaperedRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}