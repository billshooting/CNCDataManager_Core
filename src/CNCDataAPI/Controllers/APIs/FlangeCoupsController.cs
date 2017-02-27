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
    [ApiAuthorize(Policy = nameof(AuthorizationLevel.ResourceOwner))]
    [EnableCors("FullOpen")]
    [Route("api/cncdata/[controller]")]
    public class FlangeCoupsController : Controller
    {
        private CNCMachineData db;

        public FlangeCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/FlangeCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<FlangeCoup> GetFlangeCouplings()
        {
            return db.FlangeCouplings;
        }

        // GET: api/FlangeCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlangeCoup(string id)
        {
            FlangeCoup flangeCoup = await db.FlangeCouplings.FindAsync(id);
            if (flangeCoup == null)
            {
                return NotFound();
            }

            return Ok(flangeCoup);
        }

        // PUT: api/FlangeCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlangeCoup(string id, [FromBody] FlangeCoup flangeCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flangeCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(flangeCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlangeCoupExists(id))
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

        // POST: api/FlangeCoups
        [HttpPost]
        public async Task<IActionResult> PostFlangeCoup([FromBody] FlangeCoup flangeCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlangeCouplings.Add(flangeCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlangeCoupExists(flangeCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flangeCoup.TypeID }, flangeCoup);
        }

        // DELETE: api/FlangeCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlangeCoup(string id)
        {
            FlangeCoup flangeCoup = await db.FlangeCouplings.FindAsync(id);
            if (flangeCoup == null)
            {
                return NotFound();
            }

            db.FlangeCouplings.Remove(flangeCoup);
            await db.SaveChangesAsync();

            return Ok(flangeCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlangeCoupExists(string id)
        {
            return db.FlangeCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}