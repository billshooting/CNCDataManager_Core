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
    public class PlumShapedFlexibleCoupsController : Controller
    {
        private CNCMachineData db;

        public PlumShapedFlexibleCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/PlumShapedFlexibleCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<PlumShapedFlexibleCoup> GetPlumShapedFlexibleCouplings()
        {
            return db.PlumShapedFlexibleCouplings;
        }

        // GET: api/PlumShapedFlexibleCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlumShapedFlexibleCoup(string id)
        {
            PlumShapedFlexibleCoup plumShapedFlexibleCoup = await db.PlumShapedFlexibleCouplings.FindAsync(id);
            if (plumShapedFlexibleCoup == null)
            {
                return NotFound();
            }

            return Ok(plumShapedFlexibleCoup);
        }

        // PUT: api/PlumShapedFlexibleCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlumShapedFlexibleCoup(string id, [FromBody] PlumShapedFlexibleCoup plumShapedFlexibleCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plumShapedFlexibleCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(plumShapedFlexibleCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlumShapedFlexibleCoupExists(id))
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

        // POST: api/PlumShapedFlexibleCoups
        [HttpPost]
        public async Task<IActionResult> PostPlumShapedFlexibleCoup([FromBody] PlumShapedFlexibleCoup plumShapedFlexibleCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlumShapedFlexibleCouplings.Add(plumShapedFlexibleCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlumShapedFlexibleCoupExists(plumShapedFlexibleCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = plumShapedFlexibleCoup.TypeID }, plumShapedFlexibleCoup);
        }

        // DELETE: api/PlumShapedFlexibleCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlumShapedFlexibleCoup(string id)
        {
            PlumShapedFlexibleCoup plumShapedFlexibleCoup = await db.PlumShapedFlexibleCouplings.FindAsync(id);
            if (plumShapedFlexibleCoup == null)
            {
                return NotFound();
            }

            db.PlumShapedFlexibleCouplings.Remove(plumShapedFlexibleCoup);
            await db.SaveChangesAsync();

            return Ok(plumShapedFlexibleCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlumShapedFlexibleCoupExists(string id)
        {
            return db.PlumShapedFlexibleCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}