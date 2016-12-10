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
    public class SolidBallScrewNutPairsController : Controller
    {
        private CNCMachineData db;

        public SolidBallScrewNutPairsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/SolidBallScrewNutPairs
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<SolidBallScrewNutPairs> GetSolidBallScrewNutPairs()
        {
            return db.SolidBallScrewNutPairs;
        }

        // GET: api/SolidBallScrewNutPairs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSolidBallScrewNutPairs(string id)
        {
            SolidBallScrewNutPairs solidBallScrewNutPairs = await db.SolidBallScrewNutPairs.FindAsync(id);
            if (solidBallScrewNutPairs == null)
            {
                return NotFound();
            }

            return Ok(solidBallScrewNutPairs);
        }

        // PUT: api/SolidBallScrewNutPairs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolidBallScrewNutPairs(string id, SolidBallScrewNutPairs solidBallScrewNutPairs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solidBallScrewNutPairs.TypeID)
            {
                return BadRequest();
            }

            db.Entry(solidBallScrewNutPairs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolidBallScrewNutPairsExists(id))
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

        // POST: api/SolidBallScrewNutPairs
        [HttpPost]
        public async Task<IActionResult> PostSolidBallScrewNutPairs(SolidBallScrewNutPairs solidBallScrewNutPairs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SolidBallScrewNutPairs.Add(solidBallScrewNutPairs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolidBallScrewNutPairsExists(solidBallScrewNutPairs.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = solidBallScrewNutPairs.TypeID }, solidBallScrewNutPairs);
        }

        // DELETE: api/SolidBallScrewNutPairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolidBallScrewNutPairs(string id)
        {
            SolidBallScrewNutPairs solidBallScrewNutPairs = await db.SolidBallScrewNutPairs.FindAsync(id);
            if (solidBallScrewNutPairs == null)
            {
                return NotFound();
            }

            db.SolidBallScrewNutPairs.Remove(solidBallScrewNutPairs);
            await db.SaveChangesAsync();

            return Ok(solidBallScrewNutPairs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolidBallScrewNutPairsExists(string id)
        {
            return db.SolidBallScrewNutPairs.Count(e => e.TypeID == id) > 0;
        }
    }
}

