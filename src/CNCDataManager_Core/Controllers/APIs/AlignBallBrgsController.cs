using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using CNCDataManager.Models.APIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CNCDataManager.Controllers.APIs
{
    //[ApiAuthorize]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class AlignBallBrgsController : Controller
    {
        private CNCMachineData db;

        public AlignBallBrgsController(CNCMachineData database)
        {
            db = database;
        }

        // GET: api/AlignBallBrgs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<AlignBallBrg> GetAlignBallBearings()
        {
            return db.AlignBallBearings;
        }
        
        // GET: api/AlignBallBrgs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlignBallBrg(string id)
        {
            AlignBallBrg alignBallBrg = await db.AlignBallBearings.FindAsync(id);
            if (alignBallBrg == null)
            {
                return NotFound();
            }

            return Ok(alignBallBrg);
        }

        // PUT: api/AlignBallBrgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlignBallBrg(string id, AlignBallBrg alignBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alignBallBrg.TypeID)
            {
                return BadRequest();
            }

            db.Entry(alignBallBrg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlignBallBrgExists(id))
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

        // POST: api/AlignBallBrgs
        [HttpPost]
        public async Task<IActionResult> PostAlignBallBrg(AlignBallBrg alignBallBrg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlignBallBearings.Add(alignBallBrg);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlignBallBrgExists(alignBallBrg.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = alignBallBrg.TypeID }, alignBallBrg);
        }

        // DELETE: api/AlignBallBrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlignBallBrg(string id)
        {
            AlignBallBrg alignBallBrg = await db.AlignBallBearings.FindAsync(id);
            if (alignBallBrg == null)
            {
                return NotFound();
            }

            db.AlignBallBearings.Remove(alignBallBrg);
            await db.SaveChangesAsync();

            return Ok(alignBallBrg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlignBallBrgExists(string id)
        {
            return db.AlignBallBearings.Count(e => e.TypeID == id) > 0;
        }
    }
}