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
    public class HubShapedCoupsController : Controller
    {
        private CNCMachineData db;

        public HubShapedCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/HubShapedCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<HubShapedCoup> GetHubShapedCouplings()
        {
            return db.HubShapedCouplings;
        }

        // GET: api/HubShapedCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHubShapedCoup(string id)
        {
            HubShapedCoup hubShapedCoup = await db.HubShapedCouplings.FindAsync(id);
            if (hubShapedCoup == null)
            {
                return NotFound();
            }

            return Ok(hubShapedCoup);
        }

        // PUT: api/HubShapedCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHubShapedCoup(string id, HubShapedCoup hubShapedCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hubShapedCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(hubShapedCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HubShapedCoupExists(id))
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

        // POST: api/HubShapedCoups
        [HttpPost]
        public async Task<IActionResult> PostHubShapedCoup(HubShapedCoup hubShapedCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HubShapedCouplings.Add(hubShapedCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HubShapedCoupExists(hubShapedCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hubShapedCoup.TypeID }, hubShapedCoup);
        }

        // DELETE: api/HubShapedCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHubShapedCoup(string id)
        {
            HubShapedCoup hubShapedCoup = await db.HubShapedCouplings.FindAsync(id);
            if (hubShapedCoup == null)
            {
                return NotFound();
            }

            db.HubShapedCouplings.Remove(hubShapedCoup);
            await db.SaveChangesAsync();

            return Ok(hubShapedCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HubShapedCoupExists(string id)
        {
            return db.HubShapedCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}