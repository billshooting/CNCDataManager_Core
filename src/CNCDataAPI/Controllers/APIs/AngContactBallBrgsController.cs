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
    //[ApiAuthorize]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    public class AngContactBallBrgsController : Controller
    {
        private CNCMachineData db;

        public AngContactBallBrgsController(CNCMachineData database)
        {
            db = database;
        }

        // GET: api/AngContactBallBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<AngContactBallBrg> GetAngContactBallBearings()
        {
            return db.AngContactBallBearings;
        }

        // GET: api/AngContactBallBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAngContactBallBrg(string id)
        {
            AngContactBallBrg angContactBallBrg = await db.AngContactBallBearings.FindAsync(id);
            if (angContactBallBrg == null)
            {
                return NotFound();
            }

            return Ok(angContactBallBrg);
        }

        // PUT: api/AngContactBallBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAngContactBallBrg(string id, [FromBody]AngContactBallBrg angContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != angContactBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(angContactBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AngContactBallBrgExists(id))
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

        // POST: api/AngContactBallBrgs
        [HttpPost]
        public async Task<IActionResult> PostAngContactBallBrg([FromBody]AngContactBallBrg angContactBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AngContactBallBearings.Add(angContactBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AngContactBallBrgExists(angContactBallBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = angContactBallBrg.TypeID }, angContactBallBrg);
        }

        // DELETE: api/AngContactBallBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAngContactBallBrg(string id)
        {
            AngContactBallBrg angContactBallBrg = await db.AngContactBallBearings.FindAsync(id);
            if (angContactBallBrg == null)
            {
                return NotFound();
            }

            db.AngContactBallBearings.Remove(angContactBallBrg);
            await db.SaveChangesAsync();

            return Ok(angContactBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AngContactBallBrgExists(string id)
        {
            return db.AngContactBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}