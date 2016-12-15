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
    public class CylinRollerBrgsController : Controller
    {
        private CNCMachineData db;

        public CylinRollerBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/CylinRollerBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<CylinRollerBrg> GetCylinRollerBearings()
        {
            return db.CylinRollerBearings;
        }

        // GET: api/CylinRollerBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCylinRollerBrg(string id)
        {
            CylinRollerBrg cylinRollerBrg = await db.CylinRollerBearings.FindAsync(id);
            if (cylinRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(cylinRollerBrg);
        }

        // PUT: api/CylinRollerBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCylinRollerBrg(string id, [FromBody]CylinRollerBrg cylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cylinRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(cylinRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CylinRollerBrgExists(id))
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

        // POST: api/CylinRollerBrgs
        [HttpPost]
        public async Task<IActionResult> PostCylinRollerBrg([FromBody]CylinRollerBrg cylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CylinRollerBearings.Add(cylinRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CylinRollerBrgExists(cylinRollerBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cylinRollerBrg.TypeID }, cylinRollerBrg);
        }

        // DELETE: api/CylinRollerBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCylinRollerBrg(string id)
        {
            CylinRollerBrg cylinRollerBrg = await db.CylinRollerBearings.FindAsync(id);
            if (cylinRollerBrg == null)
            {
                return NotFound();
            }

            db.CylinRollerBearings.Remove(cylinRollerBrg);
            await db.SaveChangesAsync();

            return Ok(cylinRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CylinRollerBrgExists(string id)
        {
            return db.CylinRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}