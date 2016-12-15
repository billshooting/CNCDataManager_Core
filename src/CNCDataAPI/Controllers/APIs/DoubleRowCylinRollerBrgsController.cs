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
    public class DoubleRowCylinRollerBrgsController : Controller
    {
        private CNCMachineData db;

        public DoubleRowCylinRollerBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/DoubleRowCylinRollerBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<DoubleRowCylinRollerBrg> GetDoubleRowCylinRollerBearings()
        {
            return db.DoubleRowCylinRollerBearings;
        }

        // GET: api/DoubleRowCylinRollerBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoubleRowCylinRollerBrg(string id)
        {
            DoubleRowCylinRollerBrg doubleRowCylinRollerBrg = await db.DoubleRowCylinRollerBearings.FindAsync(id);
            if (doubleRowCylinRollerBrg == null)
            {
                return NotFound();
            }

            return Ok(doubleRowCylinRollerBrg);
        }

        // PUT: api/DoubleRowCylinRollerBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoubleRowCylinRollerBrg(string id, [FromBody] DoubleRowCylinRollerBrg doubleRowCylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doubleRowCylinRollerBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(doubleRowCylinRollerBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoubleRowCylinRollerBrgExists(id))
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

        // POST: api/DoubleRowCylinRollerBrgs
        [HttpPost]
        public async Task<IActionResult> PostDoubleRowCylinRollerBrg([FromBody] DoubleRowCylinRollerBrg doubleRowCylinRollerBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoubleRowCylinRollerBearings.Add(doubleRowCylinRollerBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoubleRowCylinRollerBrgExists(doubleRowCylinRollerBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doubleRowCylinRollerBrg.TypeID }, doubleRowCylinRollerBrg);
        }

        // DELETE: api/DoubleRowCylinRollerBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoubleRowCylinRollerBrg(string id)
        {
            DoubleRowCylinRollerBrg doubleRowCylinRollerBrg = await db.DoubleRowCylinRollerBearings.FindAsync(id);
            if (doubleRowCylinRollerBrg == null)
            {
                return NotFound();
            }

            db.DoubleRowCylinRollerBearings.Remove(doubleRowCylinRollerBrg);
            await db.SaveChangesAsync();

            return Ok(doubleRowCylinRollerBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubleRowCylinRollerBrgExists(string id)
        {
            return db.DoubleRowCylinRollerBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}