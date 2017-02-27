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
    public class FlexiblePinCoupsController : Controller
    {
        private CNCMachineData db;

        public FlexiblePinCoupsController(CNCMachineData data)
        {
            db = data;
        }

        // GET: api/FlexiblePinCoups
        [AllowAnonymous]
        [HttpGet]
        public IQueryable<FlexiblePinCoup> GetFlexiblePinCouplings()
        {
            return db.FlexiblePinCouplings;
        }

        // GET: api/FlexiblePinCoups/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlexiblePinCoup(string id)
        {
            FlexiblePinCoup flexiblePinCoup = await db.FlexiblePinCouplings.FindAsync(id);
            if (flexiblePinCoup == null)
            {
                return NotFound();
            }

            return Ok(flexiblePinCoup);
        }

        // PUT: api/FlexiblePinCoups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlexiblePinCoup(string id, [FromBody] FlexiblePinCoup flexiblePinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flexiblePinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(flexiblePinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlexiblePinCoupExists(id))
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

        // POST: api/FlexiblePinCoups
        [HttpPost]
        public async Task<IActionResult> PostFlexiblePinCoup([FromBody] FlexiblePinCoup flexiblePinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlexiblePinCouplings.Add(flexiblePinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlexiblePinCoupExists(flexiblePinCoup.TypeID))
                {
                    return StatusCode((int)HttpStatusCode.Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flexiblePinCoup.TypeID }, flexiblePinCoup);
        }

        // DELETE: api/FlexiblePinCoups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlexiblePinCoup(string id)
        {
            FlexiblePinCoup flexiblePinCoup = await db.FlexiblePinCouplings.FindAsync(id);
            if (flexiblePinCoup == null)
            {
                return NotFound();
            }

            db.FlexiblePinCouplings.Remove(flexiblePinCoup);
            await db.SaveChangesAsync();

            return Ok(flexiblePinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlexiblePinCoupExists(string id)
        {
            return db.FlexiblePinCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}