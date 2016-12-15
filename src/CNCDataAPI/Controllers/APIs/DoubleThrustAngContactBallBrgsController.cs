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
    public class DoubleThrustAngContactBallBrgsController : Controller
    {
        private CNCMachineData db;

        public DoubleThrustAngContactBallBrgsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/DoubleThrustAngContactBallBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<DoubleThrustAngContactBallBrg> GetDoubleThrustAngContactBallBearings()
        {
            return db.DoubleThrustAngContactBallBearings;
        }

        // GET: api/DoubleThrustAngContactBallBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoubleThrustAngContactBallBrg(string id)
        {
            DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg = await db.DoubleThrustAngContactBallBearings.FindAsync(id);
            if (doubleThrustAngContactBallBrg == null)
            {
                return NotFound();
            }

            return Ok(doubleThrustAngContactBallBrg);
        }

        // PUT: api/DoubleThrustAngContactBallBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoubleThrustAngContactBallBrg(string id, [FromBody] DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doubleThrustAngContactBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(doubleThrustAngContactBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoubleThrustAngContactBallBrgExists(id))
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

        // POST: api/DoubleThrustAngContactBallBrgs
        [HttpPost]
        public async Task<IActionResult> PostDoubleThrustAngContactBallBrg([FromBody] DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoubleThrustAngContactBallBearings.Add(doubleThrustAngContactBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoubleThrustAngContactBallBrgExists(doubleThrustAngContactBallBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doubleThrustAngContactBallBrg.TypeID }, doubleThrustAngContactBallBrg);
        }

        // DELETE: api/DoubleThrustAngContactBallBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoubleThrustAngContactBallBrg(string id)
        {
            DoubleThrustAngContactBallBrg doubleThrustAngContactBallBrg = await db.DoubleThrustAngContactBallBearings.FindAsync(id);
            if (doubleThrustAngContactBallBrg == null)
            {
                return NotFound();
            }

            db.DoubleThrustAngContactBallBearings.Remove(doubleThrustAngContactBallBrg);
            await db.SaveChangesAsync();

            return Ok(doubleThrustAngContactBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubleThrustAngContactBallBrgExists(string id)
        {
            return db.DoubleThrustAngContactBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}